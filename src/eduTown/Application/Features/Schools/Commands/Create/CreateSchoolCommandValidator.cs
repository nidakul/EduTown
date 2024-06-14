using FluentValidation;

namespace Application.Features.Schools.Commands.Create;

public class CreateSchoolCommandValidator : AbstractValidator<CreateSchoolCommand>
{
    public CreateSchoolCommandValidator()
    {
        RuleFor(c => c.CityId).NotEmpty();
        RuleFor(c => c.SchoolTypeId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}