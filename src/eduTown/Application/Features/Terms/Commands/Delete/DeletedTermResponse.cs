using NArchitecture.Core.Application.Responses;

namespace Application.Features.Terms.Commands.Delete;

public class DeletedTermResponse : IResponse
{
    public int Id { get; set; }
}