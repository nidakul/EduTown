using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class Classroom : Entity<int>
    {
        public int SchoolLessonId { get; set; }
        public string Name { get; set; }

        public virtual SchoolLesson SchoolLesson { get; set; }

        public virtual ICollection<UserCertificate> UserCertificates { get; set; }


        public Classroom()
        {
        }
    } 
}


 
