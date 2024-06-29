using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Terms.Queries.GetList;

public class GetListTermListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}