using Application.Features.PostInteractions.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.PostInteractions.Rules;

public class PostInteractionBusinessRules : BaseBusinessRules
{
    private readonly IPostInteractionRepository _postInteractionRepository;
    private readonly ILocalizationService _localizationService;

    public PostInteractionBusinessRules(IPostInteractionRepository postInteractionRepository, ILocalizationService localizationService)
    {
        _postInteractionRepository = postInteractionRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PostInteractionsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PostInteractionShouldExistWhenSelected(PostInteraction? postInteraction)
    {
        if (postInteraction == null)
            await throwBusinessException(PostInteractionsBusinessMessages.PostInteractionNotExists);
    }

    public async Task PostInteractionIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        PostInteraction? postInteraction = await _postInteractionRepository.GetAsync(
            predicate: pi => pi.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PostInteractionShouldExistWhenSelected(postInteraction);
    }
}