using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class Classroom : Entity<int>
    {
        public int SchoolLessonId { get; set; }
        public string Name { get; set; }

        public virtual SchoolLesson SchoolLesson { get; set; }

        public virtual ICollection<UserClassroom> UserClassrooms { get; set; }
        public virtual ICollection<UserCertificate> UserCertificates { get; set; }
        public virtual ICollection<SchoolClassroom> SchoolClassrooms { get; set; }
        public virtual ICollection<LessonClassroom> LessonClassrooms { get; set; }


        public Classroom()
        {
        }
    }
}





