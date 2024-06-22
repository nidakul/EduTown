using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolLessons.Queries.GetById;

public class GetByIdSchoolLessonResponse : IResponse
{
    public int Id { get; set; }
    public int SchoolId { get; set; }
    public int LessonId { get; set; }
}