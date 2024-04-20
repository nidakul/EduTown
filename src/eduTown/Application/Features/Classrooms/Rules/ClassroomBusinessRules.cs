using Application.Features.Classrooms.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Classrooms.Rules;

public class ClassroomBusinessRules : BaseBusinessRules
{
    private readonly IClassroomRepository _classroomRepository;
    private readonly ILocalizationService _localizationService;

    public ClassroomBusinessRules(IClassroomRepository classroomRepository, ILocalizationService localizationService)
    {
        _classroomRepository = classroomRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ClassroomsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ClassroomShouldExistWhenSelected(Classroom? classroom)
    {
        if (classroom == null)
            await throwBusinessException(ClassroomsBusinessMessages.ClassroomNotExists);
    }

    public async Task ClassroomIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Classroom? classroom = await _classroomRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ClassroomShouldExistWhenSelected(classroom);
    }
}