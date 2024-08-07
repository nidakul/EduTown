using NArchitecture.Core.Application.Responses;

namespace Application.Features.PostInteractions.Commands.Create;

public class CreatedPostInteractionResponse : IResponse
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public Guid UserId { get; set; }
    public bool IsFavorite { get; set; }
    public bool IsLiked { get; set; }
}