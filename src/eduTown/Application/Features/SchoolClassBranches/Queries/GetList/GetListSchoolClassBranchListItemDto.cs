using NArchitecture.Core.Application.Dtos;

namespace Application.Features.SchoolClassBranches.Queries.GetList;

public class GetListSchoolClassBranchListItemDto : IDto
{
    public int Id { get; set; }
    public int SchoolClassId { get; set; }
    public int BranchId { get; set; }
}