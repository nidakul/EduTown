using FluentValidation;

namespace Application.Features.GradeTypes.Commands.Create;

public class CreateGradeTypeCommandValidator : AbstractValidator<CreateGradeTypeCommand>
{
    public CreateGradeTypeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}