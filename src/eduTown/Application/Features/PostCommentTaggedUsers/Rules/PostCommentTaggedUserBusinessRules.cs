using Application.Features.PostCommentTaggedUsers.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.PostCommentTaggedUsers.Rules;

public class PostCommentTaggedUserBusinessRules : BaseBusinessRules
{
    private readonly IPostCommentTaggedUserRepository _postCommentTaggedUserRepository;
    private readonly ILocalizationService _localizationService;

    public PostCommentTaggedUserBusinessRules(IPostCommentTaggedUserRepository postCommentTaggedUserRepository, ILocalizationService localizationService)
    {
        _postCommentTaggedUserRepository = postCommentTaggedUserRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PostCommentTaggedUsersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PostCommentTaggedUserShouldExistWhenSelected(PostCommentTaggedUser? postCommentTaggedUser)
    {
        if (postCommentTaggedUser == null)
            await throwBusinessException(PostCommentTaggedUsersBusinessMessages.PostCommentTaggedUserNotExists);
    }

    public async Task PostCommentTaggedUserIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        PostCommentTaggedUser? postCommentTaggedUser = await _postCommentTaggedUserRepository.GetAsync(
            predicate: pctu => pctu.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PostCommentTaggedUserShouldExistWhenSelected(postCommentTaggedUser);
    }
}