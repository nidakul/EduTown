using FluentValidation;

namespace Application.Features.SchoolClasses.Commands.Create;

public class CreateSchoolClassCommandValidator : AbstractValidator<CreateSchoolClassCommand>
{
    public CreateSchoolClassCommandValidator()
    {
        RuleFor(c => c.SchoolId).NotEmpty();
        RuleFor(c => c.ClassroomId).NotEmpty();
    }
}