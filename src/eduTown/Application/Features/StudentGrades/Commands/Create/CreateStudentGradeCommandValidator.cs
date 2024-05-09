using FluentValidation;

namespace Application.Features.StudentGrades.Commands.Create;

public class CreateStudentGradeCommandValidator : AbstractValidator<CreateStudentGradeCommand>
{
    public CreateStudentGradeCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.GradeTypeId).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
        RuleFor(c => c.Grade).NotEmpty();
    }
}