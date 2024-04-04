using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class StudentExam : Entity<int>
    {
        public int StudentId { get; set; }
        public int ExamId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Exam Exam { get; set; }

        public StudentExam()
        {
        }

        public StudentExam(int id, int studentId, int examId): this()
        {
            Id = id;
            StudentId = studentId;
            ExamId = examId;
        }
    }
}

