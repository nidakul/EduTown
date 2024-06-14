using FluentValidation;

namespace Application.Features.InstructorDepartments.Commands.Update;

public class UpdateInstructorDepartmentCommandValidator : AbstractValidator<UpdateInstructorDepartmentCommand>
{
    public UpdateInstructorDepartmentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.InstructorId).NotEmpty();
        RuleFor(c => c.DepartmentId).NotEmpty();
    }
}