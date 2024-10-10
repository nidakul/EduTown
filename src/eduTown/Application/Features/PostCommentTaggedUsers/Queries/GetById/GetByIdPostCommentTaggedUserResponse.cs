using NArchitecture.Core.Application.Responses;

namespace Application.Features.PostCommentTaggedUsers.Queries.GetById;

public class GetByIdPostCommentTaggedUserResponse : IResponse
{
    public int Id { get; set; }
    public int PostCommentId { get; set; }
    public Guid TaggedUserId { get; set; }
}