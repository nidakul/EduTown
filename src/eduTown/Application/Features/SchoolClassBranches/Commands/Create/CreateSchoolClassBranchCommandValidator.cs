using FluentValidation;

namespace Application.Features.SchoolClassBranches.Commands.Create;

public class CreateSchoolClassBranchCommandValidator : AbstractValidator<CreateSchoolClassBranchCommand>
{
    public CreateSchoolClassBranchCommandValidator()
    {
        RuleFor(c => c.SchoolClassId).NotEmpty();
        RuleFor(c => c.BranchId).NotEmpty();
    }
}