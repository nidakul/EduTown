using FluentValidation;

namespace Application.Features.SchoolLessons.Commands.Delete;

public class DeleteSchoolLessonCommandValidator : AbstractValidator<DeleteSchoolLessonCommand>
{
    public DeleteSchoolLessonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}