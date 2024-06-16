using Application.Features.StudentExamDates.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.StudentExamDates.Rules;

public class StudentExamDateBusinessRules : BaseBusinessRules
{
    private readonly IStudentExamDateRepository _studentExamDateRepository;
    private readonly ILocalizationService _localizationService;

    public StudentExamDateBusinessRules(IStudentExamDateRepository studentExamDateRepository, ILocalizationService localizationService)
    {
        _studentExamDateRepository = studentExamDateRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, StudentExamDatesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task StudentExamDateShouldExistWhenSelected(StudentExamDate? studentExamDate)
    {
        if (studentExamDate == null)
            await throwBusinessException(StudentExamDatesBusinessMessages.StudentExamDateNotExists);
    }

    public async Task StudentExamDateIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        StudentExamDate? studentExamDate = await _studentExamDateRepository.GetAsync(
            predicate: sed => sed.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StudentExamDateShouldExistWhenSelected(studentExamDate);
    }
}