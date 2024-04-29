using NArchitecture.Core.Application.Responses;

namespace Application.Features.StudentGradeLessons.Queries.GetById;

public class GetByIdStudentGradeLessonResponse : IResponse
{
    public int Id { get; set; }
    public int StudentGradeId { get; set; }
    public int LessonId { get; set; }
}