using FluentValidation;

namespace Application.Features.StudentGrades.Commands.Delete;

public class DeleteStudentGradeCommandValidator : AbstractValidator<DeleteStudentGradeCommand>
{
    public DeleteStudentGradeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}