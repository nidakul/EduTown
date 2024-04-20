using FluentValidation;

namespace Application.Features.UserClassrooms.Commands.Update;

public class UpdateUserClassroomCommandValidator : AbstractValidator<UpdateUserClassroomCommand>
{
    public UpdateUserClassroomCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.ClassroomId).NotEmpty();
    }
}