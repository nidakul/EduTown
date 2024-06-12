using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolTypes.Commands.Update;

public class UpdatedSchoolTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}