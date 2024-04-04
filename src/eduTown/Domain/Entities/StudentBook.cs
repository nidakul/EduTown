using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class StudentBook : Entity<int>
    {
        public int StudentId { get; set; }
        public int BookId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Book Book { get; set; }

        public StudentBook()
        {
        }

        public StudentBook(int id, int studentId, int bookId): this()
        {
            Id = id;
            StudentId = studentId;
            BookId = bookId;
        }


    }
}

