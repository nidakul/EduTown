using FluentValidation;

namespace Application.Features.StudentExamDates.Commands.Update;

public class UpdateStudentExamDateCommandValidator : AbstractValidator<UpdateStudentExamDateCommand>
{
    public UpdateStudentExamDateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.ExamDateId).NotEmpty();
    }
}