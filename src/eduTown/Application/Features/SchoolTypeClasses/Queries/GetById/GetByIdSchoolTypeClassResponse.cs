using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolTypeClasses.Queries.GetById;

public class GetByIdSchoolTypeClassResponse : IResponse
{
    public int Id { get; set; }
    public int SchoolTypeId { get; set; }
    public int ClassroomId { get; set; }
}