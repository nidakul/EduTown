using Application.Features.SchoolClasses.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.SchoolClasses.Rules;

public class SchoolClassBusinessRules : BaseBusinessRules
{
    private readonly ISchoolClassRepository _schoolClassRepository;
    private readonly ILocalizationService _localizationService;

    public SchoolClassBusinessRules(ISchoolClassRepository schoolClassRepository, ILocalizationService localizationService)
    {
        _schoolClassRepository = schoolClassRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SchoolClassesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SchoolClassShouldExistWhenSelected(SchoolClass? schoolClass)
    {
        if (schoolClass == null)
            await throwBusinessException(SchoolClassesBusinessMessages.SchoolClassNotExists);
    }

    public async Task SchoolClassIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        SchoolClass? schoolClass = await _schoolClassRepository.GetAsync(
            predicate: sc => sc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SchoolClassShouldExistWhenSelected(schoolClass);
    }
}