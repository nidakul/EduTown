using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.Posts.Queries.GetDetail
{
    public class GetDetailByPostIdResponse : IResponse
    {
        //postu yayınlayan
        public Guid AuthorUserId { get; set; } 
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public int ClassroomId { get; set; }
        public string ClassroomName { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int LikeCount { get; set; }
        public string Message { get; set; }
        public bool IsCommentable { get; set; }
        public DateTime CreatedDate { get; set; }
        //post
        //public int PostFileId { get; set; }
        //public string FilePath { get; set; }
        //yorum
       
        //PostInteraction
        //public Guid InteractorUserId { get; set; }
        //public string InteractorFirstName { get; set; }
        //public string InteractorLastName { get; set; }
        //public bool IsFavorite { get; set; }
        //public bool IsLiked { get; set; }

        public GetDetailByPostIdResponse() 
        {
        }
    }
}





