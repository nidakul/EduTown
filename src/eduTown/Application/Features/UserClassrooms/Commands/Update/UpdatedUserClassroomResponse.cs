using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserClassrooms.Commands.Update;

public class UpdatedUserClassroomResponse : IResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int ClassroomId { get; set; }
}