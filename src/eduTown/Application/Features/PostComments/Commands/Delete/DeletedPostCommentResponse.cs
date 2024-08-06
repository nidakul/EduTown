using NArchitecture.Core.Application.Responses;

namespace Application.Features.PostComments.Commands.Delete;

public class DeletedPostCommentResponse : IResponse
{
    public int Id { get; set; }
}