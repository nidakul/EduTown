using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserClassrooms.Commands.Create;

public class CreatedUserClassroomResponse : IResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int ClassroomId { get; set; }
}