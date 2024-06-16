using FluentValidation;

namespace Application.Features.LessonExamDates.Commands.Update;

public class UpdateLessonExamDateCommandValidator : AbstractValidator<UpdateLessonExamDateCommand>
{
    public UpdateLessonExamDateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
        RuleFor(c => c.ExamDateId).NotEmpty();
    }
}