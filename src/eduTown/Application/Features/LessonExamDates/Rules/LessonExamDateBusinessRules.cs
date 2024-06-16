using Application.Features.LessonExamDates.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.LessonExamDates.Rules;

public class LessonExamDateBusinessRules : BaseBusinessRules
{
    private readonly ILessonExamDateRepository _lessonExamDateRepository;
    private readonly ILocalizationService _localizationService;

    public LessonExamDateBusinessRules(ILessonExamDateRepository lessonExamDateRepository, ILocalizationService localizationService)
    {
        _lessonExamDateRepository = lessonExamDateRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, LessonExamDatesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task LessonExamDateShouldExistWhenSelected(LessonExamDate? lessonExamDate)
    {
        if (lessonExamDate == null)
            await throwBusinessException(LessonExamDatesBusinessMessages.LessonExamDateNotExists);
    }

    public async Task LessonExamDateIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        LessonExamDate? lessonExamDate = await _lessonExamDateRepository.GetAsync(
            predicate: led => led.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LessonExamDateShouldExistWhenSelected(lessonExamDate);
    }
}