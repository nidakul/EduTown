using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class ExamDate : Entity<int>
    {
        public string ExamType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<LessonExamDate> LessonExamDate { get; set; }
        public virtual ICollection<StudentExamDate> ExamDates { get; set; }

        public ExamDate()
        {
        }
    }
}


