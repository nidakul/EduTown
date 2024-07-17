using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    //sınıfların şubeleri
    public class SchoolClassBranch : Entity<int>
    {
        public int SchoolClassId { get; set; }
        public int BranchId { get; set; }

        public virtual SchoolClass SchoolClass { get; set; }
        public virtual Branch Branch { get; set; }

        public SchoolClassBranch()
        {
        }
    }
}

