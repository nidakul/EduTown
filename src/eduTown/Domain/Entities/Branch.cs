using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    //Okul şubesi
    public class Branch : Entity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<SchoolClassBranch> SchoolClassBranches { get; set; }
        public virtual ICollection<Student> Students { get; set; }

        public Branch()
        {
        }
    }
}

