using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class UserClass:Entity<int>
    {
        public int UserId { get; set; }
        public int ClassId { get; set; }

        public virtual User User { get; set; }
        public virtual Class Class { get; set; }

        public UserClass()
        {
        }

        public UserClass(int id, int userId, int classId): this()
        {
            Id = id;
            UserId = userId;
            ClassId = classId;
        }
    }
}

