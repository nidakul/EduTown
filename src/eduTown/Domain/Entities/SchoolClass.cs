using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    //Okula ait sınıflar
    public class SchoolClass : Entity<int>
    {
        public int SchoolId { get; set; }
        public int ClassroomId { get; set; }

        public virtual School School { get; set; }
        public virtual Classroom Classroom { get; set; }

        public virtual ICollection<SchoolClassLesson> SchoolClassLessons { get; set; }

        public SchoolClass()
        {
        }
    }
}




