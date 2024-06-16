using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class UserLesson : Entity<int>
    {
        public Guid UserId { get; set; }
        public int LessonId { get; set; }

        public virtual User User { get; set; }
        public virtual Lesson Lesson { get; set; }
        public UserLesson()
        {
        }
    }
}


