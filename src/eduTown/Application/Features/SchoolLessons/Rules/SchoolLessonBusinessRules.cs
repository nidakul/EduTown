using Application.Features.SchoolLessons.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.SchoolLessons.Rules;

public class SchoolLessonBusinessRules : BaseBusinessRules
{
    private readonly ISchoolLessonRepository _schoolLessonRepository;
    private readonly ILocalizationService _localizationService;

    public SchoolLessonBusinessRules(ISchoolLessonRepository schoolLessonRepository, ILocalizationService localizationService)
    {
        _schoolLessonRepository = schoolLessonRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SchoolLessonsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SchoolLessonShouldExistWhenSelected(SchoolLesson? schoolLesson)
    {
        if (schoolLesson == null)
            await throwBusinessException(SchoolLessonsBusinessMessages.SchoolLessonNotExists);
    }

    public async Task SchoolLessonIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        SchoolLesson? schoolLesson = await _schoolLessonRepository.GetAsync(
            predicate: sl => sl.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SchoolLessonShouldExistWhenSelected(schoolLesson);
    }
}