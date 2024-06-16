using NArchitecture.Core.Application.Responses;

namespace Application.Features.LessonExamDates.Queries.GetById;

public class GetByIdLessonExamDateResponse : IResponse
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public int ExamDateId { get; set; }
}