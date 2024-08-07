using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.PostComments.Commands.Create;

public class CreatedPostCommentResponse : IResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public List<Guid> TaggedUserId { get; set; }
    public int PostId { get; set; }
    public string Comment { get; set; }
}

