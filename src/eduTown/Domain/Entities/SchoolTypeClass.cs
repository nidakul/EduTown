using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    //schoolType'ın sınıfları. Lise 9-12 gibi
    public class SchoolTypeClass : Entity<int>
    {
        public int SchoolTypeId { get; set; }
        public int ClassroomId { get; set; }

        public virtual SchoolType SchoolType { get; set; }
        public virtual Classroom Classroom { get; set; }

        public SchoolTypeClass()
        {
        }
    }
}



