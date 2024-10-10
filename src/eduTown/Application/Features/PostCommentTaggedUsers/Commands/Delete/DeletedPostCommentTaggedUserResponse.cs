using NArchitecture.Core.Application.Responses;

namespace Application.Features.PostCommentTaggedUsers.Commands.Delete;

public class DeletedPostCommentTaggedUserResponse : IResponse
{
    public int Id { get; set; }
}