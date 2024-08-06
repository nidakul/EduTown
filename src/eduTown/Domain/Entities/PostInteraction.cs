using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class PostInteraction: Entity<int>
    {
        public int PostId { get; set; }
        public Guid UserId { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsLiked { get; set; }

        public virtual Post Post { get; set; }
        //public virtual User User { get; set; }
        public PostInteraction()
        {
        }
    }
}

 