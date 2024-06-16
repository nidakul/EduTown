using FluentValidation;

namespace Application.Features.LessonExamDates.Commands.Create;

public class CreateLessonExamDateCommandValidator : AbstractValidator<CreateLessonExamDateCommand>
{
    public CreateLessonExamDateCommandValidator()
    {
        RuleFor(c => c.LessonId).NotEmpty();
        RuleFor(c => c.ExamDateId).NotEmpty();
    }
}