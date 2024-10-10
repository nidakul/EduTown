using NArchitecture.Core.Application.Dtos;

namespace Application.Features.PostCommentTaggedUsers.Queries.GetList;

public class GetListPostCommentTaggedUserListItemDto : IDto
{
    public int Id { get; set; }
    public int PostCommentId { get; set; }
    public Guid TaggedUserId { get; set; }
}