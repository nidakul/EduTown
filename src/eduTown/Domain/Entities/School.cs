using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class School: Entity<int>
    {
        public int CityId { get; set; }
        public int SchoolTypeId { get; set; }
        public string Name { get; set; }

        public virtual City City { get; set; }
        public virtual SchoolType SchoolType { get; set; }

        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual ICollection<SchoolClassroom> SchoolClassrooms { get; set; }
        public virtual ICollection<SchoolLesson> SchoolLessons { get; set; }


        public School()
        {
        }

        public School(int id, int cityId, string name): this()
        {
            Id = id;
            CityId = cityId;
            Name = name;
        }
    }
}




