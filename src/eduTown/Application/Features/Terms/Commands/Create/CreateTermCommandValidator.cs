using FluentValidation;

namespace Application.Features.Terms.Commands.Create;

public class CreateTermCommandValidator : AbstractValidator<CreateTermCommand>
{
    public CreateTermCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}