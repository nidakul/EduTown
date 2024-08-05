using NArchitecture.Core.Application.Dtos;

namespace Application.Features.PostInteractions.Queries.GetList;

public class GetListPostInteractionListItemDto : IDto
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public Guid UserId { get; set; }
    public string Comment { get; set; }
    public bool IsFavorite { get; set; }
    public bool IsLiked { get; set; }
}