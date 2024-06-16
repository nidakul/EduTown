using NArchitecture.Core.Application.Dtos;

namespace Application.Features.LessonExamDates.Queries.GetList;

public class GetListLessonExamDateListItemDto : IDto
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public int ExamDateId { get; set; }
}