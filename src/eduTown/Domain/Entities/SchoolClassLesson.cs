using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    //Okuldaki sınıflara ait dersler
    public class SchoolClassLesson : Entity<int>
    {
        public int SchoolClassId { get; set; }
        public int LessonId { get; set; }

        public virtual SchoolClass SchoolClass { get; set; }
        public virtual Lesson Lesson { get; set; }
        public SchoolClassLesson()
        {
        }
    }

}


