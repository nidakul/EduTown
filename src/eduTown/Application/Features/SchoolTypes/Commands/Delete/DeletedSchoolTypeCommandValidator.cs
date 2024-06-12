using FluentValidation;

namespace Application.Features.SchoolTypes.Commands.Delete;

public class DeleteSchoolTypeCommandValidator : AbstractValidator<DeleteSchoolTypeCommand>
{
    public DeleteSchoolTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}