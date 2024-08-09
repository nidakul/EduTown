using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.Posts.Queries.GetCommentByPostId
{
    public class GetCommentByPostIdResponse : IResponse
    {
        public Guid CommenterUserId { get; set; }
        public string CommenterFirstName { get; set; }
        public string CommenterLastName { get; set; }
        public List<Guid> TaggedUserId { get; set; }
        public List<string> TaggedFirstName { get; set; }
        public List<string> TaggedLastName { get; set; }
        public List<string> Comments { get; set; }
        public DateTime CommentCreatedDate { get; set; }

        public GetCommentByPostIdResponse()
        {
        }
    }
}

