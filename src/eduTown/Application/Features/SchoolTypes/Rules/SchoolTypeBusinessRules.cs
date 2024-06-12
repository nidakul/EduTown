using Application.Features.SchoolTypes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.SchoolTypes.Rules;

public class SchoolTypeBusinessRules : BaseBusinessRules
{
    private readonly ISchoolTypeRepository _schoolTypeRepository;
    private readonly ILocalizationService _localizationService;

    public SchoolTypeBusinessRules(ISchoolTypeRepository schoolTypeRepository, ILocalizationService localizationService)
    {
        _schoolTypeRepository = schoolTypeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SchoolTypesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SchoolTypeShouldExistWhenSelected(SchoolType? schoolType)
    {
        if (schoolType == null)
            await throwBusinessException(SchoolTypesBusinessMessages.SchoolTypeNotExists);
    }

    public async Task SchoolTypeIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        SchoolType? schoolType = await _schoolTypeRepository.GetAsync(
            predicate: st => st.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SchoolTypeShouldExistWhenSelected(schoolType);
    }
}