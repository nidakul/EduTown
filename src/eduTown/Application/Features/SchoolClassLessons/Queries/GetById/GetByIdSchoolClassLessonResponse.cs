using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolClassLessons.Queries.GetById;

public class GetByIdSchoolClassLessonResponse : IResponse
{
    public int Id { get; set; }
    public int SchoolClassId { get; set; }
    public int LessonId { get; set; }
}