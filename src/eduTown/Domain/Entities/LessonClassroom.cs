using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class LessonClassroom: Entity<int>
    {
        public int LessonId { get; set; }
        public int ClassroomId { get; set; }

        public virtual Lesson Lesson { get; set; }
        public virtual Classroom Classroom { get; set; }

        public LessonClassroom()
        {
        }
    }
}


