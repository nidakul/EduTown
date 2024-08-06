using Application.Features.PostComments.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.PostComments.Rules;

public class PostCommentBusinessRules : BaseBusinessRules
{
    private readonly IPostCommentRepository _postCommentRepository;
    private readonly ILocalizationService _localizationService;

    public PostCommentBusinessRules(IPostCommentRepository postCommentRepository, ILocalizationService localizationService)
    {
        _postCommentRepository = postCommentRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PostCommentsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PostCommentShouldExistWhenSelected(PostComment? postComment)
    {
        if (postComment == null)
            await throwBusinessException(PostCommentsBusinessMessages.PostCommentNotExists);
    }

    public async Task PostCommentIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        PostComment? postComment = await _postCommentRepository.GetAsync(
            predicate: pc => pc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PostCommentShouldExistWhenSelected(postComment);
    }
}