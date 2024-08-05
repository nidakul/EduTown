using NArchitecture.Core.Application.Responses;

namespace Application.Features.PostInteractions.Commands.Delete;

public class DeletedPostInteractionResponse : IResponse
{
    public int Id { get; set; }
}