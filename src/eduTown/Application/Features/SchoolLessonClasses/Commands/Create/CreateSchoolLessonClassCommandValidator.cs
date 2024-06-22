using FluentValidation;

namespace Application.Features.SchoolLessonClasses.Commands.Create;

public class CreateSchoolLessonClassCommandValidator : AbstractValidator<CreateSchoolLessonClassCommand>
{
    public CreateSchoolLessonClassCommandValidator()
    {
    }
}