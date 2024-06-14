using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class InstructorDepartment : Entity<int>
    {
        public int InstructorId { get; set; }
        public int DepartmentId { get; set; }

        public virtual Instructor Instructor { get; set; }
        public virtual Department Department { get; set; }

        public InstructorDepartment()
        {
        }
    }
}



