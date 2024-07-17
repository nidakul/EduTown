using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolClassBranches.Commands.Delete;

public class DeletedSchoolClassBranchResponse : IResponse
{
    public int Id { get; set; }
}