using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class UserCertificate : Entity<int>
    {
        public Guid UserId { get; set; }
        public int CertificateId { get; set; }
        public int ClassroomId { get; set; }
        public DateTime Year { get; set; }
        public int Semester { get; set; }

        public virtual User User { get; set; }
        public virtual Certificate Certificate { get; set; }
        public virtual Classroom Classroom { get; set; }

        public UserCertificate()
        {
        }
    }
}

