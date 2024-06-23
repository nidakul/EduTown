using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Classrooms.Queries.GetList;

public class GetListClassroomListItemDto : IDto
{
    public int Id { get; set; }
    public int SchoolLessonId { get; set; }
    public string Name { get; set; }
}