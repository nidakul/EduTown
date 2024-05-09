using NArchitecture.Core.Application.Dtos;

namespace Application.Features.GradeTypes.Queries.GetList;

public class GetListGradeTypeListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int GradeCount { get; set; }
}