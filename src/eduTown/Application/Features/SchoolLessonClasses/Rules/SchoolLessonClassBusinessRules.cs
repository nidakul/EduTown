using Application.Features.SchoolLessonClasses.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.SchoolLessonClasses.Rules;

public class SchoolLessonClassBusinessRules : BaseBusinessRules
{
    private readonly ISchoolLessonClassRepository _schoolLessonClassRepository;
    private readonly ILocalizationService _localizationService;

    public SchoolLessonClassBusinessRules(ISchoolLessonClassRepository schoolLessonClassRepository, ILocalizationService localizationService)
    {
        _schoolLessonClassRepository = schoolLessonClassRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SchoolLessonClassesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SchoolLessonClassShouldExistWhenSelected(SchoolLessonClass? schoolLessonClass)
    {
        if (schoolLessonClass == null)
            await throwBusinessException(SchoolLessonClassesBusinessMessages.SchoolLessonClassNotExists);
    }

    public async Task SchoolLessonClassIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        SchoolLessonClass? schoolLessonClass = await _schoolLessonClassRepository.GetAsync(
            predicate: slc => slc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SchoolLessonClassShouldExistWhenSelected(schoolLessonClass);
    }
}