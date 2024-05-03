using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolClassrooms.Commands.Create;

public class CreatedSchoolClassroomResponse : IResponse
{
    public int Id { get; set; }
    public int SchoolId { get; set; }
    public int ClassroomId { get; set; }
}