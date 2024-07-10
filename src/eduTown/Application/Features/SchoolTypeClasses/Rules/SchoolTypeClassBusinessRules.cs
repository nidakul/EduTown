using Application.Features.SchoolTypeClasses.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.SchoolTypeClasses.Rules;

public class SchoolTypeClassBusinessRules : BaseBusinessRules
{
    private readonly ISchoolTypeClassRepository _schoolTypeClassRepository;
    private readonly ILocalizationService _localizationService;

    public SchoolTypeClassBusinessRules(ISchoolTypeClassRepository schoolTypeClassRepository, ILocalizationService localizationService)
    {
        _schoolTypeClassRepository = schoolTypeClassRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SchoolTypeClassesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SchoolTypeClassShouldExistWhenSelected(SchoolTypeClass? schoolTypeClass)
    {
        if (schoolTypeClass == null)
            await throwBusinessException(SchoolTypeClassesBusinessMessages.SchoolTypeClassNotExists);
    }

    public async Task SchoolTypeClassIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        SchoolTypeClass? schoolTypeClass = await _schoolTypeClassRepository.GetAsync(
            predicate: stc => stc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SchoolTypeClassShouldExistWhenSelected(schoolTypeClass);
    }
}