using Application.Features.GradeTypes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.GradeTypes.Rules;

public class GradeTypeBusinessRules : BaseBusinessRules
{
    private readonly IGradeTypeRepository _gradeTypeRepository;
    private readonly ILocalizationService _localizationService;

    public GradeTypeBusinessRules(IGradeTypeRepository gradeTypeRepository, ILocalizationService localizationService)
    {
        _gradeTypeRepository = gradeTypeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, GradeTypesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task GradeTypeShouldExistWhenSelected(GradeType? gradeType)
    {
        if (gradeType == null)
            await throwBusinessException(GradeTypesBusinessMessages.GradeTypeNotExists);
    }

    public async Task GradeTypeIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        GradeType? gradeType = await _gradeTypeRepository.GetAsync(
            predicate: gt => gt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await GradeTypeShouldExistWhenSelected(gradeType);
    }
}