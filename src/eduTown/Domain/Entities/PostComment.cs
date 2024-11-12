using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class PostComment : Entity<int>
    {
        public Guid UserId { get; set; }
        public int PostId { get; set; }
        public string Comment { get; set; }

        public int? ParentCommentId { get; set; } // Eğer bir yoruma cevap ise, bu alan parent yorumun ID'sini tutacak.
        public virtual PostComment ParentComment { get; set; } // İlişkili parent yorum
        public virtual ICollection<PostComment> Replies { get; set; } // Bu yoruma yapılmış cevaplar

        //public virtual ICollection<PostCommentTaggedUser> TaggedUsers { get; set; } // Etiketlenen kullanıcılar
        public virtual Post Post { get; set; }

        public PostComment()
        {
        } 
    }
}
  
