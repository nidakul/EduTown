using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolTypes.Commands.Create;

public class CreatedSchoolTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}