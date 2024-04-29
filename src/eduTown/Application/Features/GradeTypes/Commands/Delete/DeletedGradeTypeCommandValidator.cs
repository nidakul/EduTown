using FluentValidation;

namespace Application.Features.GradeTypes.Commands.Delete;

public class DeleteGradeTypeCommandValidator : AbstractValidator<DeleteGradeTypeCommand>
{
    public DeleteGradeTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}