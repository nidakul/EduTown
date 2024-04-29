using FluentValidation;

namespace Application.Features.StudentGrades.Commands.Update;

public class UpdateStudentGradeCommandValidator : AbstractValidator<UpdateStudentGradeCommand>
{
    public UpdateStudentGradeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.GradeTypeId).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
        RuleFor(c => c.ExamCount).NotEmpty();
        RuleFor(c => c.Grade).NotEmpty();
    }
}