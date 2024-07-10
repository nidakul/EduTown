using FluentValidation;

namespace Application.Features.SchoolTypeClasses.Commands.Update;

public class UpdateSchoolTypeClassCommandValidator : AbstractValidator<UpdateSchoolTypeClassCommand>
{
    public UpdateSchoolTypeClassCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.SchoolTypeId).NotEmpty();
        RuleFor(c => c.ClassroomId).NotEmpty();
    }
}