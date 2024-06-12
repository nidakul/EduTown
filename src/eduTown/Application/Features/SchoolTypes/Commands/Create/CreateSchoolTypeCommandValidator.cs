using FluentValidation;

namespace Application.Features.SchoolTypes.Commands.Create;

public class CreateSchoolTypeCommandValidator : AbstractValidator<CreateSchoolTypeCommand>
{
    public CreateSchoolTypeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}