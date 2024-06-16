using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class LessonExamDate: Entity<int>
    {
        public int LessonId { get; set; }
        public int ExamDateId { get; set; }

        public virtual Lesson Lesson { get; set; }
        public virtual ExamDate ExamDate { get; set; }

        public LessonExamDate()
        {
        }
    }
}

