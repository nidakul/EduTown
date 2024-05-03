using FluentValidation;

namespace Application.Features.LessonClassrooms.Commands.Update;

public class UpdateLessonClassroomCommandValidator : AbstractValidator<UpdateLessonClassroomCommand>
{
    public UpdateLessonClassroomCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
        RuleFor(c => c.ClassroomId).NotEmpty();
    }
}