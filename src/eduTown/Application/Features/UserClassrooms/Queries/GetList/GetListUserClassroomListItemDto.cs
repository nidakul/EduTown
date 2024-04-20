using NArchitecture.Core.Application.Dtos;

namespace Application.Features.UserClassrooms.Queries.GetList;

public class GetListUserClassroomListItemDto : IDto
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int ClassroomId { get; set; }
}