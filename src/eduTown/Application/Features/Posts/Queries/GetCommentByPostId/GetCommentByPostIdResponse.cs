using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.Posts.Queries.GetCommentByPostId
{
    public class GetCommentByPostIdResponse : IResponse
    {
        public int CommentId { get; set; }
        public int? ParentCommentId { get; set; } // Parent yorumu varsa onun ID'sini tutacak.
        //public GetCommentByPostIdResponse ParentComment { get; set; }

        public List<TaggedUserResponse> TaggedUsers { get; set; } // Etiketlenen kullanıcıların listesi
        public List<GetCommentByPostIdResponse> Replies { get; set; } // Bu yoruma yapılmış cevaplar
        public List<CommenterResponse> Commenters { get; set; } // Bu yoruma yapılmış cevaplar
        
        public GetCommentByPostIdResponse()
        {
            TaggedUsers = new List<TaggedUserResponse>();
            Replies = new List<GetCommentByPostIdResponse>();
            Commenters = new List<CommenterResponse>();
        }
    }

    public class TaggedUserResponse
    {
        public Guid TaggedUserId { get; set; }
        public string TaggedFirstName { get; set; }
        public string TaggedLastName { get; set; }
    }

    public class CommenterResponse
    {
        public Guid CommenterUserId { get; set; }
        public string CommenterImageUrl { get; set; }
        public string CommenterFirstName { get; set; }
        public string CommenterLastName { get; set; }
        public string Comment { get; set; }
        public DateTime CommentCreatedDate { get; set; }
    }
}

