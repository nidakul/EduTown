using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class UserSchool: Entity<int>
    {
        public Guid UserId{ get; set; }
        public int SchoolId { get; set; }

        public virtual User User { get; set; }
        public virtual School School { get; set; }

        public UserSchool()
        {
        }
    }
}


