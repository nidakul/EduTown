using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class StudentGradeLesson: Entity<int>
    {
        public int StudentGradeId { get; set; }
        public int LessonId { get; set; }

        //public virtual StudentGrade StudentGrade { get; set; }
        public virtual Lesson Lesson { get; set; }

        public StudentGradeLesson()
        {
        }
    }
}


