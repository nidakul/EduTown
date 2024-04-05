using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class Class : Entity<int>
    {
        public int GradeId { get; set; }
        public string Name { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual ICollection<UserClass> UserClasses { get; set; }

        public Class() 
        {
        }

        public Class(int id ,int gradeId, string name) : this()
        {
            Id = id;
            GradeId = gradeId;
            Name = name;
        }
    }
}

