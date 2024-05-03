using NArchitecture.Core.Application.Dtos;

namespace Application.Features.SchoolClassrooms.Queries.GetList;

public class GetListSchoolClassroomListItemDto : IDto
{
    public int Id { get; set; }
    public int SchoolId { get; set; }
    public int ClassroomId { get; set; }
}