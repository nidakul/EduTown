using NArchitecture.Core.Application.Responses;

namespace Application.Features.Terms.Commands.Update;

public class UpdatedTermResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}