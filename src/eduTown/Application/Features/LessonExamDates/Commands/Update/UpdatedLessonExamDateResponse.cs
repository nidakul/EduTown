using NArchitecture.Core.Application.Responses;

namespace Application.Features.LessonExamDates.Commands.Update;

public class UpdatedLessonExamDateResponse : IResponse
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public int ExamDateId { get; set; }
}