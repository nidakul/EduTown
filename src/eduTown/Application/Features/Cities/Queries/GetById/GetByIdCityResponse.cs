using NArchitecture.Core.Application.Responses;

namespace Application.Features.Cities.Queries.GetById;

public class GetByIdCityResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}