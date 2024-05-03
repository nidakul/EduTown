using NArchitecture.Core.Application.Dtos;

namespace Application.Features.LessonClassrooms.Queries.GetList;

public class GetListLessonClassroomListItemDto : IDto
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public int ClassroomId { get; set; }
}