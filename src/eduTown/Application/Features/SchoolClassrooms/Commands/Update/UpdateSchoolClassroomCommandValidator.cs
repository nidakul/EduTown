using FluentValidation;

namespace Application.Features.SchoolClassrooms.Commands.Update;

public class UpdateSchoolClassroomCommandValidator : AbstractValidator<UpdateSchoolClassroomCommand>
{
    public UpdateSchoolClassroomCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.SchoolId).NotEmpty();
        RuleFor(c => c.ClassroomId).NotEmpty();
    }
}