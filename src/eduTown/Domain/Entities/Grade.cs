using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class Grade : Entity<int>
    {
        //şube
        public int CertificateId { get; set; }
        public int ClassId { get; set; }
        public string Name { get; set; }

        public virtual Certificate Certificate { get; set; }
        public virtual Class Class { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<UserGrade> UserGrades { get; set; }

        public Grade()
        {
        }

        public Grade(int id, int classId, int certificateId, string name): this()
        {
            Id = id;
            ClassId = classId;
            CertificateId = certificateId;
            Name = name;
        }
    }
}
