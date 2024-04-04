using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class Class : Entity<int>
    {
        public int StudentId { get; set; }
        public int GradeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Student { get; set; }
        public virtual Grade Grade { get; set; }

        public Class()
        {
        }
    }
}

