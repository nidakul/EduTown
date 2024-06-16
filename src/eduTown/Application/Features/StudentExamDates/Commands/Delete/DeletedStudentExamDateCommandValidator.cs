using FluentValidation;

namespace Application.Features.StudentExamDates.Commands.Delete;

public class DeleteStudentExamDateCommandValidator : AbstractValidator<DeleteStudentExamDateCommand>
{
    public DeleteStudentExamDateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}