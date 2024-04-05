using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class Book : Entity<int>
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }

        public virtual Author Author { get; set; }
        public virtual ICollection<UserBook> UserBooks { get; set; }

        public Book()
        {
        }

        public Book(int id, int authorId, string name):this()
        {
            Id = id;
            AuthorId = authorId;
            Name = name;
        }
    }
}
