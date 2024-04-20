using FluentValidation;

namespace Application.Features.UserClassrooms.Commands.Delete;

public class DeleteUserClassroomCommandValidator : AbstractValidator<DeleteUserClassroomCommand>
{
    public DeleteUserClassroomCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}