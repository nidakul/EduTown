using FluentValidation;

namespace Application.Features.ExamDates.Commands.Update;

public class UpdateExamDateCommandValidator : AbstractValidator<UpdateExamDateCommand>
{
    public UpdateExamDateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ExamType).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
    }
}