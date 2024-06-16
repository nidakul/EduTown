using FluentValidation;

namespace Application.Features.StudentExamDates.Commands.Create;

public class CreateStudentExamDateCommandValidator : AbstractValidator<CreateStudentExamDateCommand>
{
    public CreateStudentExamDateCommandValidator()
    {
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.ExamDateId).NotEmpty();
    }
}