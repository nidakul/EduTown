using FluentValidation;

namespace Application.Features.SchoolClassrooms.Commands.Create;

public class CreateSchoolClassroomCommandValidator : AbstractValidator<CreateSchoolClassroomCommand>
{
    public CreateSchoolClassroomCommandValidator()
    {
        RuleFor(c => c.SchoolId).NotEmpty();
        RuleFor(c => c.ClassroomId).NotEmpty();
    }
}