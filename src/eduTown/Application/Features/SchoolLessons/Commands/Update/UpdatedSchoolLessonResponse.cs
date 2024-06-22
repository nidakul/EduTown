using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolLessons.Commands.Update;

public class UpdatedSchoolLessonResponse : IResponse
{
    public int Id { get; set; }
    public int SchoolId { get; set; }
    public int LessonId { get; set; }
}