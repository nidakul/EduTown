using NArchitecture.Core.Application.Responses;

namespace Application.Features.Terms.Commands.Create;

public class CreatedTermResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}