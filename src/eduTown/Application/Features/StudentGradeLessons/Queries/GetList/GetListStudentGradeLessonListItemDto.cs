using NArchitecture.Core.Application.Dtos;

namespace Application.Features.StudentGradeLessons.Queries.GetList;

public class GetListStudentGradeLessonListItemDto : IDto
{
    public int Id { get; set; }
    public int StudentGradeId { get; set; }
    public int LessonId { get; set; }
}