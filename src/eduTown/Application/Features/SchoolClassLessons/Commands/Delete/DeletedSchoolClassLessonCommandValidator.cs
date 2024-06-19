using FluentValidation;

namespace Application.Features.SchoolClassLessons.Commands.Delete;

public class DeleteSchoolClassLessonCommandValidator : AbstractValidator<DeleteSchoolClassLessonCommand>
{
    public DeleteSchoolClassLessonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}