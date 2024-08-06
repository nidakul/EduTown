using NArchitecture.Core.Application.Responses;

namespace Application.Features.PostComments.Commands.Update;

public class UpdatedPostCommentResponse : IResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int PostId { get; set; }
    public string Comment { get; set; }
}