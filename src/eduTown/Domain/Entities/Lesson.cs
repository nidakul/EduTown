using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class Lesson: Entity<int>
    {
        public int SchoolClassLessonId { get; set; }
        public string Name { get; set; }

        public virtual SchoolClassLesson SchoolClassLesson{ get; set; }

        //public virtual ICollection<StudentGradeLesson> StudentGradeLessons { get; set; }
        public virtual ICollection<StudentGrade> StudentGrade { get; set; }
        public virtual ICollection<LessonClassroom> LessonClassrooms { get; set; }
        public virtual ICollection<LessonExamDate> LessonExamDate { get; set; }


        public Lesson()
        {
        } 
    } 
}
  