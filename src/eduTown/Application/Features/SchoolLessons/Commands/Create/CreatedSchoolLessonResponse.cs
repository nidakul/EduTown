using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolLessons.Commands.Create;

public class CreatedSchoolLessonResponse : IResponse
{
    public int Id { get; set; }
    public int SchoolId { get; set; }
    public int LessonId { get; set; }
}