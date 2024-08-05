using FluentValidation;

namespace Application.Features.PostFiles.Commands.Create;

public class CreatePostFileCommandValidator : AbstractValidator<CreatePostFileCommand>
{
    public CreatePostFileCommandValidator()
    {
        RuleFor(c => c.PostId).NotEmpty();
        RuleFor(c => c.FilePath).NotEmpty();
    }
}