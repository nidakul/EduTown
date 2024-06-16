using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class StudentExamDate : Entity<int>
    {
        public Guid StudentId { get; set; }
        public int ExamDateId { get; set; }

        public virtual Student Student { get; set; }
        public virtual ExamDate ExamDate { get; set; }

        public StudentExamDate()
        {
        }
    }
}
