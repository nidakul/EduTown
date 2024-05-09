using NArchitecture.Core.Application.Responses;

namespace Application.Features.GradeTypes.Commands.Update;

public class UpdatedGradeTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int GradeCount { get; set; }
}