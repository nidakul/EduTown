using FluentValidation;

namespace Application.Features.SchoolClassrooms.Commands.Delete;

public class DeleteSchoolClassroomCommandValidator : AbstractValidator<DeleteSchoolClassroomCommand>
{
    public DeleteSchoolClassroomCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}