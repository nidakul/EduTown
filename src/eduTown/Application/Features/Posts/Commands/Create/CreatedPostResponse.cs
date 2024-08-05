using NArchitecture.Core.Application.Responses;

namespace Application.Features.Posts.Commands.Create;

public class CreatedPostResponse : IResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int SchoolId { get; set; }
    public int ClassroomId { get; set; }
    public int BranchId { get; set; }
    public int LikeCount { get; set; }
    public string Message { get; set; }
    public bool IsCommentable { get; set; }
}