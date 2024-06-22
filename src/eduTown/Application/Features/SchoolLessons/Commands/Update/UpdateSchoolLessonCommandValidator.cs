using FluentValidation;

namespace Application.Features.SchoolLessons.Commands.Update;

public class UpdateSchoolLessonCommandValidator : AbstractValidator<UpdateSchoolLessonCommand>
{
    public UpdateSchoolLessonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.SchoolId).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
    }
}