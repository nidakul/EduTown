using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolClassBranches.Queries.GetById;

public class GetByIdSchoolClassBranchResponse : IResponse
{
    public int Id { get; set; }
    public int SchoolClassId { get; set; }
    public int BranchId { get; set; }
}