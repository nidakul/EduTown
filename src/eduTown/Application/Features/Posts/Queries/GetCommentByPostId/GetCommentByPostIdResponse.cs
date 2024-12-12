using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.Posts.Queries.GetCommentByPostId
{
    public class GetCommentByPostIdResponse : IResponse
    {
        public int? ParentCommentId { get; set; } // Eğer bu yorum bir yanıt ise, ana yorumun ID'sini tutacak.

        public List<CommenterDto> Commenters { get; set; }

        public GetCommentByPostIdResponse() 
        {
        } 
    }

    public class CommenterDto
    {
        public int CommentId { get; set; }
        public Guid CommenterUserId { get; set; } // Yorumu yapan kişinin UserId'si
        public string CommenterImageUrl { get; set; } // Yorumu yapan kişinin profil resmi
        public string CommenterFirstName { get; set; } // Yorumu yapan kişinin adı
        public string CommenterLastName { get; set; }
        public string Comment { get; set; } // Yorumu tutacak.
        public DateTime CommentCreatedDate { get; set; }
        public List<TaggedUserResponse> TaggedUsers { get; set; } 
        public List<RepliesResponse> Replies { get; set; }
    }

    // Etiketlenen kullanıcıları tutacak yapı
    public class TaggedUserResponse
    {
        public Guid TaggedUserId { get; set; } // Etiketlenen kullanıcının UserId'si
        public string TaggedFirstName { get; set; } // Etiketlenen kullanıcının adı
        public string TaggedLastName { get; set; } // Etiketlenen kullanıcının soyadı
    }

    public class RepliesResponse
    {
        public List<GetCommentByPostIdResponse> Replies { get; set; } // Bu yoruma yapılmış yanıtlar

    }
}

