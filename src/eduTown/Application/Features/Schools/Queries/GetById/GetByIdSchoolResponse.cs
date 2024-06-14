using NArchitecture.Core.Application.Responses;

namespace Application.Features.Schools.Queries.GetById;

public class GetByIdSchoolResponse : IResponse
{
    public int Id { get; set; }
    public int CityId { get; set; }
    public int SchoolTypeId { get; set; }
    public string Name { get; set; }
}