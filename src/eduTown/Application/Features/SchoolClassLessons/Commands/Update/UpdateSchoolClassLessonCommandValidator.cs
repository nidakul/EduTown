using FluentValidation;

namespace Application.Features.SchoolClassLessons.Commands.Update;

public class UpdateSchoolClassLessonCommandValidator : AbstractValidator<UpdateSchoolClassLessonCommand>
{
    public UpdateSchoolClassLessonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.SchoolClassId).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
    }
}