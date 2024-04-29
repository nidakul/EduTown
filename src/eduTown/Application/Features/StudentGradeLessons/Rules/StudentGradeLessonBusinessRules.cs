using Application.Features.StudentGradeLessons.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.StudentGradeLessons.Rules;

public class StudentGradeLessonBusinessRules : BaseBusinessRules
{
    private readonly IStudentGradeLessonRepository _studentGradeLessonRepository;
    private readonly ILocalizationService _localizationService;

    public StudentGradeLessonBusinessRules(IStudentGradeLessonRepository studentGradeLessonRepository, ILocalizationService localizationService)
    {
        _studentGradeLessonRepository = studentGradeLessonRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, StudentGradeLessonsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task StudentGradeLessonShouldExistWhenSelected(StudentGradeLesson? studentGradeLesson)
    {
        if (studentGradeLesson == null)
            await throwBusinessException(StudentGradeLessonsBusinessMessages.StudentGradeLessonNotExists);
    }

    public async Task StudentGradeLessonIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        StudentGradeLesson? studentGradeLesson = await _studentGradeLessonRepository.GetAsync(
            predicate: sgl => sgl.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StudentGradeLessonShouldExistWhenSelected(studentGradeLesson);
    }
}