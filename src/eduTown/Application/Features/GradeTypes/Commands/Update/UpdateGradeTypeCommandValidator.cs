using FluentValidation;

namespace Application.Features.GradeTypes.Commands.Update;

public class UpdateGradeTypeCommandValidator : AbstractValidator<UpdateGradeTypeCommand>
{
    public UpdateGradeTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}