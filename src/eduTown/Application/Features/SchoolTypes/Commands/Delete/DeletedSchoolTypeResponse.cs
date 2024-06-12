using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolTypes.Commands.Delete;

public class DeletedSchoolTypeResponse : IResponse
{
    public int Id { get; set; }
}