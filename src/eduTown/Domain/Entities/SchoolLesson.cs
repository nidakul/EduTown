using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    //Okula ait dersler
    public class SchoolLesson : Entity<int>
    {
        public int SchoolId { get; set; }
        public int LessonId { get; set; }

        public virtual School School { get; set; }
        public virtual Lesson Lesson { get; set; }

        public virtual ICollection<Classroom> Classrooms { get; set; }
        
        public SchoolLesson()
        {
        }
    }
}

