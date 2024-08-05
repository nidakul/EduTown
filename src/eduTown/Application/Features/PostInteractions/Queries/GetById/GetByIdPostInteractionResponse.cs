using NArchitecture.Core.Application.Responses;

namespace Application.Features.PostInteractions.Queries.GetById;

public class GetByIdPostInteractionResponse : IResponse
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public Guid UserId { get; set; }
    public string Comment { get; set; }
    public bool IsFavorite { get; set; }
    public bool IsLiked { get; set; }
}