using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.Posts.Queries.GetCommentByPostId
{
    public class GetCommentByPostIdResponse : IResponse
    {
        public int CommentId { get; set; }
        public Guid CommenterUserId { get; set; }
        public string CommenterImgUrl { get; set; }
        public string CommenterFirstName { get; set; }
        public string CommenterLastName { get; set; }
        public string Comment { get; set; }
        public DateTime CommentCreatedDate { get; set; }
        public int? ParentCommentId { get; set; } // Parent yorumu varsa onun ID'sini tutacak.
        public List<TaggedUserResponse> TaggedUsers { get; set; } // Etiketlenen kullanıcıların listesi
        public List<GetCommentByPostIdResponse> Replies { get; set; } // Bu yoruma yapılmış cevaplar

        public GetCommentByPostIdResponse()
        {
        }
    }
}

