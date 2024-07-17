using FluentValidation;

namespace Application.Features.SchoolClassBranches.Commands.Update;

public class UpdateSchoolClassBranchCommandValidator : AbstractValidator<UpdateSchoolClassBranchCommand>
{
    public UpdateSchoolClassBranchCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.SchoolClassId).NotEmpty();
        RuleFor(c => c.BranchId).NotEmpty();
    }
}