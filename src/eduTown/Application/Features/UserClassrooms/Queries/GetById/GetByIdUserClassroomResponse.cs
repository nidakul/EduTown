using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserClassrooms.Queries.GetById;

public class GetByIdUserClassroomResponse : IResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int ClassroomId { get; set; }
}