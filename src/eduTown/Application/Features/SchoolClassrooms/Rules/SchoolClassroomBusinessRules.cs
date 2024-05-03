using Application.Features.SchoolClassrooms.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.SchoolClassrooms.Rules;

public class SchoolClassroomBusinessRules : BaseBusinessRules
{
    private readonly ISchoolClassroomRepository _schoolClassroomRepository;
    private readonly ILocalizationService _localizationService;

    public SchoolClassroomBusinessRules(ISchoolClassroomRepository schoolClassroomRepository, ILocalizationService localizationService)
    {
        _schoolClassroomRepository = schoolClassroomRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SchoolClassroomsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SchoolClassroomShouldExistWhenSelected(SchoolClassroom? schoolClassroom)
    {
        if (schoolClassroom == null)
            await throwBusinessException(SchoolClassroomsBusinessMessages.SchoolClassroomNotExists);
    }

    public async Task SchoolClassroomIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        SchoolClassroom? schoolClassroom = await _schoolClassroomRepository.GetAsync(
            predicate: sc => sc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SchoolClassroomShouldExistWhenSelected(schoolClassroom);
    }
}