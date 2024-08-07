using NArchitecture.Core.Application.Responses;

namespace Application.Features.StudentGrades.Commands.Create;

public class CreatedStudentGradeResponse : IResponse
{
    public int Id { get; set; }
    public Guid StudentId { get; set; }
    public int ClassroomId { get; set; }
    public int LessonId { get; set; }  
    public int GradeTypeId { get; set; }
    public int TermId { get; set; }
    public int ExamCount { get; set; }
    public double Grade { get; set; }
}

