using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolClassLessons.Commands.Create;

public class CreatedSchoolClassLessonResponse : IResponse
{
    public int Id { get; set; }
    public int SchoolClassId { get; set; }
    public int LessonId { get; set; }
}