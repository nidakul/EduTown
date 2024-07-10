using FluentValidation;

namespace Application.Features.SchoolTypeClasses.Commands.Create;

public class CreateSchoolTypeClassCommandValidator : AbstractValidator<CreateSchoolTypeClassCommand>
{
    public CreateSchoolTypeClassCommandValidator()
    {
        RuleFor(c => c.SchoolTypeId).NotEmpty();
        RuleFor(c => c.ClassroomId).NotEmpty();
    }
}