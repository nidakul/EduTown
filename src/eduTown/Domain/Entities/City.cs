using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class City : Entity<int>
    {
        public int SchoolId { get; set; }
        public string Name { get; set; }

        public virtual School School { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }

        public City()
        {
        }

        public City(int id, int schoolId, string name): this()
        {
            Id = id;
            SchoolId = schoolId;
            Name = name;
        }

       
    }
}

