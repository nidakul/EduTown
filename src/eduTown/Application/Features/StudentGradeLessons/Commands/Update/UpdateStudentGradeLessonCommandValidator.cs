using FluentValidation;

namespace Application.Features.StudentGradeLessons.Commands.Update;

public class UpdateStudentGradeLessonCommandValidator : AbstractValidator<UpdateStudentGradeLessonCommand>
{
    public UpdateStudentGradeLessonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StudentGradeId).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
    }
}