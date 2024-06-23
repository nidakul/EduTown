using FluentValidation;

namespace Application.Features.SchoolClasses.Commands.Delete;

public class DeleteSchoolClassCommandValidator : AbstractValidator<DeleteSchoolClassCommand>
{
    public DeleteSchoolClassCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}