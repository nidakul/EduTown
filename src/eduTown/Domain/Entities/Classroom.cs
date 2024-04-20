using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class Classroom : Entity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<UserClassroom> UserClassrooms { get; set; }

        public Classroom()
        {
        }
    }
}


