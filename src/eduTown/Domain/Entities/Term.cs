using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class Term : Entity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<StudentGrade> StudentGrades { get; set; }

        public Term()
        {
        }
    }
}


