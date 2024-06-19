using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    //Okulun sınıfına göre ders atanan kısım
    public class SchoolClassLesson: Entity<int>
    {
        public int SchoolClassroomId { get; set; }
        public int LessonId { get; set; }

        public virtual SchoolClassroom SchoolClassroom { get; set; }
        public virtual Lesson Lesson { get; set; }

        public SchoolClassLesson()
        {
        }
    }
}


