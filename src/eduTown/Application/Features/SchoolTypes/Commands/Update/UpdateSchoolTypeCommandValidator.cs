using FluentValidation;

namespace Application.Features.SchoolTypes.Commands.Update;

public class UpdateSchoolTypeCommandValidator : AbstractValidator<UpdateSchoolTypeCommand>
{
    public UpdateSchoolTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}