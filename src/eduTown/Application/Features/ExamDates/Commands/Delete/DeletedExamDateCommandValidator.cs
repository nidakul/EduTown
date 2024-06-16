using FluentValidation;

namespace Application.Features.ExamDates.Commands.Delete;

public class DeleteExamDateCommandValidator : AbstractValidator<DeleteExamDateCommand>
{
    public DeleteExamDateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}