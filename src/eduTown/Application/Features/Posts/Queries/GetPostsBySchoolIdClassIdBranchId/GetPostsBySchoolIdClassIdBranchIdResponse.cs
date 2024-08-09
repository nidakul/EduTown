using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.Posts.Queries.GetPostsBySchoolIdClassIdBranchId
{
    public class GetPostsBySchoolIdClassIdBranchIdResponse: IResponse
    {
        public int SchoolId { get; set; }
        public int ClassroomId { get; set; }
        public string ClassroomName { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }

        public List<PostDto> Posts { get; set; }

        public GetPostsBySchoolIdClassIdBranchIdResponse()
        {
        }
    }

    public class PostDto
    {
        public int PostId { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public int LikeCount { get; set; }
        public string Message { get; set; }
        public bool IsCommentable { get; set; }
        public List<string> FilePaths { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}


