using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    //Okulun sınıfına göre ders atanan kısım
    public class SchoolClassLesson: Entity<int>
    {
        public int SchoolId { get; set; }
        public int ClassroomId { get; set; }

        public virtual School School { get; set; }
        public virtual Classroom Classroom { get; set; }
        public virtual ICollection<Lesson> Lesson { get; set; }

        public SchoolClassLesson()
        {
        }
    }
}
