using NArchitecture.Core.Application.Responses;

namespace Application.Features.StudentGradeLessons.Commands.Update;

public class UpdatedStudentGradeLessonResponse : IResponse
{
    public int Id { get; set; }
    public int StudentGradeId { get; set; }
    public int LessonId { get; set; }
}