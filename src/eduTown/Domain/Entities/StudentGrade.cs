using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class StudentGrade : Entity<int>
    {
        public Guid UserId { get; set; }
        public int GradeTypeId { get; set; }
        public int LessonId { get; set; }
        public int ExamCount { get; set; }
        public double Grade { get; set; }

        public virtual User User { get; set; }
        public virtual GradeType GradeType { get; set; }
        public virtual Lesson Lesson { get; set; }

        //public virtual ICollection<StudentGradeLesson> StudentGradeLessons { get; set; }

        public StudentGrade()
        {
        }
    }  
}
 


