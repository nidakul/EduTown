using NArchitecture.Core.Application.Responses;

namespace Application.Features.StudentGrades.Commands.Create;

public class CreatedStudentGradeResponse : IResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int GradeTypeId { get; set; }
    public int LessonId { get; set; }
    public int ExamCount { get; set; }
    public double Grade { get; set; }
}