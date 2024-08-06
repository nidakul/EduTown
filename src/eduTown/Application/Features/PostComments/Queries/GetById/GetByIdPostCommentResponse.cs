using NArchitecture.Core.Application.Responses;

namespace Application.Features.PostComments.Queries.GetById;

public class GetByIdPostCommentResponse : IResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int PostId { get; set; }
    public string Comment { get; set; }
}