using Application.Features.InstructorDepartments.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.InstructorDepartments.Rules;

public class InstructorDepartmentBusinessRules : BaseBusinessRules
{
    private readonly IInstructorDepartmentRepository _instructorDepartmentRepository;
    private readonly ILocalizationService _localizationService;

    public InstructorDepartmentBusinessRules(IInstructorDepartmentRepository instructorDepartmentRepository, ILocalizationService localizationService)
    {
        _instructorDepartmentRepository = instructorDepartmentRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, InstructorDepartmentsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task InstructorDepartmentShouldExistWhenSelected(InstructorDepartment? instructorDepartment)
    {
        if (instructorDepartment == null)
            await throwBusinessException(InstructorDepartmentsBusinessMessages.InstructorDepartmentNotExists);
    }

    public async Task InstructorDepartmentIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        InstructorDepartment? instructorDepartment = await _instructorDepartmentRepository.GetAsync(
            predicate: i => i.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await InstructorDepartmentShouldExistWhenSelected(instructorDepartment);
    }
}