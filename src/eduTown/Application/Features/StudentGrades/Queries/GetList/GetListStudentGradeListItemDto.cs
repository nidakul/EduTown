using NArchitecture.Core.Application.Dtos;

namespace Application.Features.StudentGrades.Queries.GetList;

public class GetListStudentGradeListItemDto : IDto
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int GradeTypeId { get; set; }
    public int LessonId { get; set; }
    public int ExamCount { get; set; }
    public double Grade { get; set; }
}