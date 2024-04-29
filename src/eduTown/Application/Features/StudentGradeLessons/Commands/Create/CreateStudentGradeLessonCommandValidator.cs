using FluentValidation;

namespace Application.Features.StudentGradeLessons.Commands.Create;

public class CreateStudentGradeLessonCommandValidator : AbstractValidator<CreateStudentGradeLessonCommand>
{
    public CreateStudentGradeLessonCommandValidator()
    {
        RuleFor(c => c.StudentGradeId).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
    }
}