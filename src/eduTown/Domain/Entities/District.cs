using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class District : Entity<int>
    {
        public District()
        {
        }

        public District(int schoolId, string name)
        {
            SchoolId = schoolId;
            Name = name;
        }

        public int SchoolId { get; set; }
        public string Name { get; set; }

        public virtual School School { get; set; }

        public virtual ICollection<Student> Student { get; set; }
        public virtual ICollection<Instructor> Instructor { get; set; }
    }
}

