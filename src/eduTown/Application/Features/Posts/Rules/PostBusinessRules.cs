using Application.Features.Posts.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Posts.Rules;

public class PostBusinessRules : BaseBusinessRules
{
    private readonly IPostRepository _postRepository;
    private readonly ILocalizationService _localizationService;

    public PostBusinessRules(IPostRepository postRepository, ILocalizationService localizationService)
    {
        _postRepository = postRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PostsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PostShouldExistWhenSelected(Post? post)
    {
        if (post == null)
            await throwBusinessException(PostsBusinessMessages.PostNotExists);
    }

    public async Task PostIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Post? post = await _postRepository.GetAsync(
            predicate: p => p.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PostShouldExistWhenSelected(post);
    }
}