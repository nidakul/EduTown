using Application.Features.LessonClassrooms.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.LessonClassrooms.Rules;

public class LessonClassroomBusinessRules : BaseBusinessRules
{
    private readonly ILessonClassroomRepository _lessonClassroomRepository;
    private readonly ILocalizationService _localizationService;

    public LessonClassroomBusinessRules(ILessonClassroomRepository lessonClassroomRepository, ILocalizationService localizationService)
    {
        _lessonClassroomRepository = lessonClassroomRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, LessonClassroomsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task LessonClassroomShouldExistWhenSelected(LessonClassroom? lessonClassroom)
    {
        if (lessonClassroom == null)
            await throwBusinessException(LessonClassroomsBusinessMessages.LessonClassroomNotExists);
    }

    public async Task LessonClassroomIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        LessonClassroom? lessonClassroom = await _lessonClassroomRepository.GetAsync(
            predicate: lc => lc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LessonClassroomShouldExistWhenSelected(lessonClassroom);
    }
}