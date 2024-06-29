using FluentValidation;

namespace Application.Features.Terms.Commands.Update;

public class UpdateTermCommandValidator : AbstractValidator<UpdateTermCommand>
{
    public UpdateTermCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}