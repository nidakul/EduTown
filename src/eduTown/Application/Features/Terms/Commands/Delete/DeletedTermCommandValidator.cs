using FluentValidation;

namespace Application.Features.Terms.Commands.Delete;

public class DeleteTermCommandValidator : AbstractValidator<DeleteTermCommand>
{
    public DeleteTermCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}