using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class Exam : Entity<int>
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }

        public virtual ICollection<UserExam> UserExams { get; set; }

        public Exam()
        {
        }

        public Exam(int id, string name, DateTime time) : this()
        {
            Id = id;
            Name = name;
            Time = time;
        }
    }
}


