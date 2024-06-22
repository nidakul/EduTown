using FluentValidation;

namespace Application.Features.SchoolLessonClasses.Commands.Delete;

public class DeleteSchoolLessonClassCommandValidator : AbstractValidator<DeleteSchoolLessonClassCommand>
{
    public DeleteSchoolLessonClassCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}