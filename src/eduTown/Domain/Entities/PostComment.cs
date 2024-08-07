using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class PostComment : Entity<int>
    {
        public Guid UserId { get; set; } //yorum yapan
        public Guid TaggedUserId { get; set; } //Etiketlenen, yorum yapılan kullanıcılar
        public int PostId { get; set; }
        public string Comment { get; set; }

        //public virtual User User { get; set; }
        public virtual Post Post { get; set; }

        public PostComment()
        {
        }
    }
}
 
