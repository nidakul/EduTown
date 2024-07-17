using Application.Features.SchoolClassBranches.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.SchoolClassBranches.Rules;

public class SchoolClassBranchBusinessRules : BaseBusinessRules
{
    private readonly ISchoolClassBranchRepository _schoolClassBranchRepository;
    private readonly ILocalizationService _localizationService;

    public SchoolClassBranchBusinessRules(ISchoolClassBranchRepository schoolClassBranchRepository, ILocalizationService localizationService)
    {
        _schoolClassBranchRepository = schoolClassBranchRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SchoolClassBranchesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SchoolClassBranchShouldExistWhenSelected(SchoolClassBranch? schoolClassBranch)
    {
        if (schoolClassBranch == null)
            await throwBusinessException(SchoolClassBranchesBusinessMessages.SchoolClassBranchNotExists);
    }

    public async Task SchoolClassBranchIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        SchoolClassBranch? schoolClassBranch = await _schoolClassBranchRepository.GetAsync(
            predicate: scb => scb.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SchoolClassBranchShouldExistWhenSelected(schoolClassBranch);
    }
}