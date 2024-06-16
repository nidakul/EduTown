using NArchitecture.Core.Application.Dtos;

namespace Application.Features.UserLessons.Queries.GetList;

public class GetListUserLessonListItemDto : IDto
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int LessonId { get; set; }
}