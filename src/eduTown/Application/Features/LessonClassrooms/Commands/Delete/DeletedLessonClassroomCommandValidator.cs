using FluentValidation;

namespace Application.Features.LessonClassrooms.Commands.Delete;

public class DeleteLessonClassroomCommandValidator : AbstractValidator<DeleteLessonClassroomCommand>
{
    public DeleteLessonClassroomCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}