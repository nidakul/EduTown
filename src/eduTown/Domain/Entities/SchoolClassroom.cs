using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class SchoolClassroom: Entity<int>
    {
        public int SchoolId { get; set; }
        public int ClassroomId { get; set; }

        public virtual School School { get; set; }
        public virtual Classroom Classroom { get; set; }

        public SchoolClassroom()
        {
        }
    }
}

