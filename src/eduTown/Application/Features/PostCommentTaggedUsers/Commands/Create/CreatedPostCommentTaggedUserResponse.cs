using NArchitecture.Core.Application.Responses;

namespace Application.Features.PostCommentTaggedUsers.Commands.Create;

public class CreatedPostCommentTaggedUserResponse : IResponse
{
    public int Id { get; set; }
    public int PostCommentId { get; set; }
    public Guid TaggedUserId { get; set; }
}      