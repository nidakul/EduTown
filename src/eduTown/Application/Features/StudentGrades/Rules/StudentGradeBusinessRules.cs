using Application.Features.StudentGrades.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.StudentGrades.Rules;

public class StudentGradeBusinessRules : BaseBusinessRules
{
    private readonly IStudentGradeRepository _studentGradeRepository;
    private readonly ILocalizationService _localizationService;

    public StudentGradeBusinessRules(IStudentGradeRepository studentGradeRepository, ILocalizationService localizationService)
    {
        _studentGradeRepository = studentGradeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, StudentGradesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task StudentGradeShouldExistWhenSelected(StudentGrade? studentGrade)
    {
        if (studentGrade == null)
            await throwBusinessException(StudentGradesBusinessMessages.StudentGradeNotExists);
    }

    public async Task StudentGradeIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        StudentGrade? studentGrade = await _studentGradeRepository.GetAsync(
            predicate: sg => sg.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StudentGradeShouldExistWhenSelected(studentGrade);
    }
}