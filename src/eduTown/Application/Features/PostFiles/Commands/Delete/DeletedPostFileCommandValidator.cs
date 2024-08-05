using FluentValidation;

namespace Application.Features.PostFiles.Commands.Delete;

public class DeletePostFileCommandValidator : AbstractValidator<DeletePostFileCommand>
{
    public DeletePostFileCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}