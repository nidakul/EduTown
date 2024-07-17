using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolClassBranches.Commands.Create;

public class CreatedSchoolClassBranchResponse : IResponse
{
    public int Id { get; set; }
    public int SchoolClassId { get; set; }
    public int BranchId { get; set; }
}