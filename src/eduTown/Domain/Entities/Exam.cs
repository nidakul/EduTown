using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class Exam : Entity<int>
    {
        public Exam()
        {
        }

        public Exam(int studentId, string name, DateTime time)
        {
            StudentId = studentId;
            Name = name;
            Time = time;
        }

        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }

        public virtual Student Student { get; set; }
    }
}


