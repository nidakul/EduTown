using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class School: Entity<int>
    {
        public int CityId { get; set; }
        public string Name { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<UserSchool> UserSchools { get; set; }

        public School()
        {
        }

        public School(int id, string name): this()
        {
            Id = id;
            Name = name;
        }
    }
}



