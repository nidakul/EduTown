using FluentValidation;

namespace Application.Features.SchoolClassBranches.Commands.Delete;

public class DeleteSchoolClassBranchCommandValidator : AbstractValidator<DeleteSchoolClassBranchCommand>
{
    public DeleteSchoolClassBranchCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}