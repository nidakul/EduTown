using NArchitecture.Core.Application.Dtos;

namespace Application.Features.PostComments.Queries.GetList;

public class GetListPostCommentListItemDto : IDto
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int PostId { get; set; }
    public string Comment { get; set; }
}