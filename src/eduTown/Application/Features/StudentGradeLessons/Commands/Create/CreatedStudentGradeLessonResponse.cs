using NArchitecture.Core.Application.Responses;

namespace Application.Features.StudentGradeLessons.Commands.Create;

public class CreatedStudentGradeLessonResponse : IResponse
{
    public int Id { get; set; }
    public int StudentGradeId { get; set; }
    public int LessonId { get; set; }
}