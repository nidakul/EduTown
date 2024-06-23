using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolClasses.Queries.GetById;

public class GetByIdSchoolClassResponse : IResponse
{
    public int Id { get; set; }
    public int SchoolId { get; set; }
    public int ClassroomId { get; set; }
}