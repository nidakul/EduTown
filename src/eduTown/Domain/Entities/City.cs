using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class City : Entity<int>
    {
        public City()
        {
        }

        public City(int schoolId, string name)
        {
            SchoolId = schoolId;
            Name = name;
        }

        public int SchoolId { get; set; }
        public string Name { get; set; }

        public virtual School School{ get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
    }
}

