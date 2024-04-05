using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class UserInstructor: Entity<int> { 

        public int UserId  { get; set; }
        public int InstructorId { get; set; }

        public virtual User User { get; set; }
        public virtual Instructor Instructor { get; set; }

        public UserInstructor()
        {
        }

        public UserInstructor(int id, int userId, int instructorId) : this()
        {
            Id = id;
            UserId = userId;
            InstructorId = instructorId;
        }
    }
}


