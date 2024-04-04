using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class Book : Entity<int>
    {
        public int AuthorId { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }

        public virtual Student Student { get; set; }
        public virtual Author Author { get; set; }

        public Book()
        {
        }

        public Book(int authorId, int studentId, string name)
        {
            AuthorId = authorId;
            StudentId = studentId;
            Name = name;
        }
    }
}
