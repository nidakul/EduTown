using FluentValidation;

namespace Application.Features.SchoolTypeClasses.Commands.Delete;

public class DeleteSchoolTypeClassCommandValidator : AbstractValidator<DeleteSchoolTypeClassCommand>
{
    public DeleteSchoolTypeClassCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}