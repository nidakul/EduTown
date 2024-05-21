using FluentValidation;

namespace Application.Features.Students.Commands.Create;

public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentCommandValidator()
    {
        //RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.StudentNo).NotEmpty();
    }
}