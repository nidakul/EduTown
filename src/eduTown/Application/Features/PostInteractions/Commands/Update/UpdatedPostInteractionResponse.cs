using NArchitecture.Core.Application.Responses;

namespace Application.Features.PostInteractions.Commands.Update;

public class UpdatedPostInteractionResponse : IResponse
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public Guid UserId { get; set; }
    public string Comment { get; set; }
    public bool IsFavorite { get; set; }
    public bool IsLiked { get; set; }
}