using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    //Öğrencinin notları
    public class StudentGrade : Entity<int>
    {
        public Guid StudentId { get; set; }
        public int GradeTypeId { get; set; } 
        public int LessonId { get; set; }
        public int ClassroomId { get; set; }
        public int TermId { get; set; } 
        public int ExamCount { get; set; } //GradeType ile ilişkili
        public double Grade { get; set; } 
         
        //public virtual Student Student { get; set; }
        public virtual GradeType GradeType { get; set; } 
        public virtual Classroom Classroom { get; set; }
        public virtual Lesson Lesson { get; set; }
        public virtual Term Term { get; set; }

        public StudentGrade() 
        {
        } 
    }   
}  






