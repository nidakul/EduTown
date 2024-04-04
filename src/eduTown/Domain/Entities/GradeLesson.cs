using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class GradeLesson : Entity<int>
    {
        public int GradeId { get; set; }
        public int LessonId { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual Lesson Lesson { get; set; }

        public GradeLesson()
        {
        }
    }
}

