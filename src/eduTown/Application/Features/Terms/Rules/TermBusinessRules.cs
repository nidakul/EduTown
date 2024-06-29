using Application.Features.Terms.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Terms.Rules;

public class TermBusinessRules : BaseBusinessRules
{
    private readonly ITermRepository _termRepository;
    private readonly ILocalizationService _localizationService;

    public TermBusinessRules(ITermRepository termRepository, ILocalizationService localizationService)
    {
        _termRepository = termRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, TermsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task TermShouldExistWhenSelected(Term? term)
    {
        if (term == null)
            await throwBusinessException(TermsBusinessMessages.TermNotExists);
    }

    public async Task TermIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Term? term = await _termRepository.GetAsync(
            predicate: t => t.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TermShouldExistWhenSelected(term);
    }
}