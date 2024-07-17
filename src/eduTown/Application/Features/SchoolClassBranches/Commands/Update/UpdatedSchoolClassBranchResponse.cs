using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolClassBranches.Commands.Update;

public class UpdatedSchoolClassBranchResponse : IResponse
{
    public int Id { get; set; }
    public int SchoolClassId { get; set; }
    public int BranchId { get; set; }
}