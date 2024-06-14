using FluentValidation;

namespace Application.Features.InstructorDepartments.Commands.Create;

public class CreateInstructorDepartmentCommandValidator : AbstractValidator<CreateInstructorDepartmentCommand>
{
    public CreateInstructorDepartmentCommandValidator()
    {
        RuleFor(c => c.InstructorId).NotEmpty();
        RuleFor(c => c.DepartmentId).NotEmpty();
    }
}