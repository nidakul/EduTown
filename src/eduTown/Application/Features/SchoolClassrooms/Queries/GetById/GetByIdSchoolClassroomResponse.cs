using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolClassrooms.Queries.GetById;

public class GetByIdSchoolClassroomResponse : IResponse
{
    public int Id { get; set; }
    public int SchoolId { get; set; }
    public int ClassroomId { get; set; }
}