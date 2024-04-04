using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class School : Entity<int>
    {
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string Name { get; set; }

        public virtual District District { get; set; }
        public virtual City City { get; set; }

        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual ICollection<Student> Students { get; set; } 
    }
}