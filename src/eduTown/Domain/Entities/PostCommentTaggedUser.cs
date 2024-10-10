using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class PostCommentTaggedUser : Entity<int>
    {
        public int PostCommentId { get; set; }
        public Guid TaggedUserId { get; set; }  

        public virtual PostComment PostComment { get; set; }

        public PostCommentTaggedUser()
        {
        } 
    }
}

 
 