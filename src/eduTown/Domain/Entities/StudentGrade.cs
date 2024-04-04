using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class StudentGrade: Entity<int>
    {
        public int StudentId { get; set; }
        public int GradeId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Grade Grade { get; set; }

        public StudentGrade()
        {
        }

        public StudentGrade(int id, int studentId, int gradeId): this()
        {
            Id = id;
            StudentId = studentId;
            GradeId = gradeId;
        }
    }
}

