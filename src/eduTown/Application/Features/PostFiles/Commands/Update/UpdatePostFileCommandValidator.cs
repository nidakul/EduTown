using FluentValidation;

namespace Application.Features.PostFiles.Commands.Update;

public class UpdatePostFileCommandValidator : AbstractValidator<UpdatePostFileCommand>
{
    public UpdatePostFileCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.PostId).NotEmpty();
        RuleFor(c => c.FilePath).NotEmpty();
    }
}