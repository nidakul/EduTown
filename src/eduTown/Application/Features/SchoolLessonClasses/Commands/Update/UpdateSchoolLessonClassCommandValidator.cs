using FluentValidation;

namespace Application.Features.SchoolLessonClasses.Commands.Update;

public class UpdateSchoolLessonClassCommandValidator : AbstractValidator<UpdateSchoolLessonClassCommand>
{
    public UpdateSchoolLessonClassCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}