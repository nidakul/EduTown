using FluentValidation;

namespace Application.Features.LessonClassrooms.Commands.Create;

public class CreateLessonClassroomCommandValidator : AbstractValidator<CreateLessonClassroomCommand>
{
    public CreateLessonClassroomCommandValidator()
    {
        RuleFor(c => c.LessonId).NotEmpty();
        RuleFor(c => c.ClassroomId).NotEmpty();
    }
}