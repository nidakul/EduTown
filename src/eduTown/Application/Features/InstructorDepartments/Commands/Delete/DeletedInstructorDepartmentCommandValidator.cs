using FluentValidation;

namespace Application.Features.InstructorDepartments.Commands.Delete;

public class DeleteInstructorDepartmentCommandValidator : AbstractValidator<DeleteInstructorDepartmentCommand>
{
    public DeleteInstructorDepartmentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}