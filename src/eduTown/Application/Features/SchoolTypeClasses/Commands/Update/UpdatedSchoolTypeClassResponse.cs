using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolTypeClasses.Commands.Update;

public class UpdatedSchoolTypeClassResponse : IResponse
{
    public int Id { get; set; }
    public int SchoolTypeId { get; set; }
    public int ClassroomId { get; set; }
}