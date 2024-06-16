using FluentValidation;

namespace Application.Features.ExamDates.Commands.Create;

public class CreateExamDateCommandValidator : AbstractValidator<CreateExamDateCommand>
{
    public CreateExamDateCommandValidator()
    {
        RuleFor(c => c.ExamType).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
    }
}