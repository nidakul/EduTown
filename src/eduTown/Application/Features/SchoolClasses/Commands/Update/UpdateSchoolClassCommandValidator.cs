using FluentValidation;

namespace Application.Features.SchoolClasses.Commands.Update;

public class UpdateSchoolClassCommandValidator : AbstractValidator<UpdateSchoolClassCommand>
{
    public UpdateSchoolClassCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.SchoolId).NotEmpty();
        RuleFor(c => c.ClassroomId).NotEmpty();
    }
}