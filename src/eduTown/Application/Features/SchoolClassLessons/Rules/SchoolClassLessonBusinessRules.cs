using Application.Features.SchoolClassLessons.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.SchoolClassLessons.Rules;

public class SchoolClassLessonBusinessRules : BaseBusinessRules
{
    private readonly ISchoolClassLessonRepository _schoolClassLessonRepository;
    private readonly ILocalizationService _localizationService;

    public SchoolClassLessonBusinessRules(ISchoolClassLessonRepository schoolClassLessonRepository, ILocalizationService localizationService)
    {
        _schoolClassLessonRepository = schoolClassLessonRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SchoolClassLessonsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SchoolClassLessonShouldExistWhenSelected(SchoolClassLesson? schoolClassLesson)
    {
        if (schoolClassLesson == null)
            await throwBusinessException(SchoolClassLessonsBusinessMessages.SchoolClassLessonNotExists);
    }

    public async Task SchoolClassLessonIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        SchoolClassLesson? schoolClassLesson = await _schoolClassLessonRepository.GetAsync(
            predicate: scl => scl.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SchoolClassLessonShouldExistWhenSelected(schoolClassLesson);
    }
}