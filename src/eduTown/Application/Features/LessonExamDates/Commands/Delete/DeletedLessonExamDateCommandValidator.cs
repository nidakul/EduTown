using FluentValidation;

namespace Application.Features.LessonExamDates.Commands.Delete;

public class DeleteLessonExamDateCommandValidator : AbstractValidator<DeleteLessonExamDateCommand>
{
    public DeleteLessonExamDateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}