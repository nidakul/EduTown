using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class Student : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public int ClassroomId { get; set; }
        public int BranchId { get; set; }
        public string StudentNo { get; set; }
        public DateTime Birthdate { get; set; }
        public string Birthplace { get; set; }

        public virtual User User { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Classroom Classroom { get; set; }

        public virtual ICollection<StudentGrade>? StudentGrades { get; set; }
        public virtual ICollection<StudentExamDate> StudentExamDates { get; set; }

        public Student()
        {
        } 
    }
}
  
 
