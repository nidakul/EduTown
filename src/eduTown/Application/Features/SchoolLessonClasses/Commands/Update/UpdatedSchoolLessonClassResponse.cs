using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolLessonClasses.Commands.Update;

public class UpdatedSchoolLessonClassResponse : IResponse
{
    public int Id { get; set; }
}