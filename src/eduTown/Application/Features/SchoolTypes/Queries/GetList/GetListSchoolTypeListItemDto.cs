using NArchitecture.Core.Application.Dtos;

namespace Application.Features.SchoolTypes.Queries.GetList;

public class GetListSchoolTypeListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}