using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class Instructor: Entity<Guid>
    {
        public Guid UserId { get; set; }
        public string Department { get; set; }

        public virtual User User { get; set; }

        public Instructor() 
        {
        }
    }
}

