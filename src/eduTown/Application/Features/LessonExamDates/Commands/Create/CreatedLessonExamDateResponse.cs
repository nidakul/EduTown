using NArchitecture.Core.Application.Responses;

namespace Application.Features.LessonExamDates.Commands.Create;

public class CreatedLessonExamDateResponse : IResponse
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public int ExamDateId { get; set; }
}