using NArchitecture.Core.Application.Responses;

namespace Application.Features.PostCommentTaggedUsers.Commands.Update;

public class UpdatedPostCommentTaggedUserResponse : IResponse
{
    public int Id { get; set; }
    public int PostCommentId { get; set; }
    public Guid UserId { get; set; }
}