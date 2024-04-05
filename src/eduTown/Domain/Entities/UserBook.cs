using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class UserBook: Entity<int>
    {
        public int UserId { get; set; }
        public int BookId { get; set; }

        public virtual User User { get; set; }
        public virtual Book Book { get; set; }

        public UserBook()
        {
        }

        public UserBook(int id, int userId, int bookId): this()
        {
            Id = id;
            UserId = userId;
            BookId = bookId;
        }
    }
}

