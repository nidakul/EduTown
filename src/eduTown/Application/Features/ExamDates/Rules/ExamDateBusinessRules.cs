using Application.Features.ExamDates.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.ExamDates.Rules;

public class ExamDateBusinessRules : BaseBusinessRules
{
    private readonly IExamDateRepository _examDateRepository;
    private readonly ILocalizationService _localizationService;

    public ExamDateBusinessRules(IExamDateRepository examDateRepository, ILocalizationService localizationService)
    {
        _examDateRepository = examDateRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ExamDatesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ExamDateShouldExistWhenSelected(ExamDate? examDate)
    {
        if (examDate == null)
            await throwBusinessException(ExamDatesBusinessMessages.ExamDateNotExists);
    }

    public async Task ExamDateIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ExamDate? examDate = await _examDateRepository.GetAsync(
            predicate: ed => ed.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ExamDateShouldExistWhenSelected(examDate);
    }
}