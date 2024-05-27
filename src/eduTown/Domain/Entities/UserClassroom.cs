using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class UserClassroom : Entity<int>
    {
        public Guid UserId { get; set; }
        public int ClassroomId { get; set; }

        public virtual User User { get; set; }
        public virtual Classroom Classroom { get; set; }


        public UserClassroom()
        {
        }
    }
}

