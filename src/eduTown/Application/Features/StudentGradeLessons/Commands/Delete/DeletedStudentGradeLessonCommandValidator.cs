using FluentValidation;

namespace Application.Features.StudentGradeLessons.Commands.Delete;

public class DeleteStudentGradeLessonCommandValidator : AbstractValidator<DeleteStudentGradeLessonCommand>
{
    public DeleteStudentGradeLessonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}