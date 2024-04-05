using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class UserExam : Entity<int>
    {
        public int UserId { get; set; }
        public int ExamId { get; set; }

        public virtual User User { get; set; }
        public virtual Exam Exam { get; set; }
        
        public UserExam()
        {
        }

        public UserExam(int id, int userId, int examId) : this()
        {
            Id = id;
            UserId = userId;
            ExamId = examId;
        }
    }
}

