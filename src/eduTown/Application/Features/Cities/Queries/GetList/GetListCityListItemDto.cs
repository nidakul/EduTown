using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Cities.Queries.GetList;

public class GetListCityListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}