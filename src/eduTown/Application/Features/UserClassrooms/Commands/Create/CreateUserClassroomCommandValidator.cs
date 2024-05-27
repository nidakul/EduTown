using FluentValidation;

namespace Application.Features.UserClassrooms.Commands.Create;

public class CreateUserClassroomCommandValidator : AbstractValidator<CreateUserClassroomCommand>
{
    public CreateUserClassroomCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.ClassroomId).NotEmpty();
    }
}