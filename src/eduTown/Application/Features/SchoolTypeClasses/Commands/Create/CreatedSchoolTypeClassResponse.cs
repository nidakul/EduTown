using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolTypeClasses.Commands.Create;

public class CreatedSchoolTypeClassResponse : IResponse
{
    public int Id { get; set; }
    public int SchoolTypeId { get; set; }
    public int ClassroomId { get; set; }
}