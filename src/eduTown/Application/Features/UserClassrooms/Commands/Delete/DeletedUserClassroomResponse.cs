using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserClassrooms.Commands.Delete;

public class DeletedUserClassroomResponse : IResponse
{
    public int Id { get; set; }
}