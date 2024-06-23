using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolClasses.Commands.Create;

public class CreatedSchoolClassResponse : IResponse
{
    public int Id { get; set; }
    public int SchoolId { get; set; }
    public int ClassroomId { get; set; }
}