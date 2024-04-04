using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class StudentInstructor : Entity<int>
    {

        public int StudentId { get; set; }
        public int InstructorId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Instructor Instructor { get; set; }

        public StudentInstructor()
        {
        }

        public StudentInstructor(int id, int studentId, int instructorId): this()
        {
            Id = id;
            StudentId = studentId;
            InstructorId = instructorId;
        }

    }
}



