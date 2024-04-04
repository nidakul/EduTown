using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class Author : Entity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public Author()
        {
        }

        public Author(string name)
        {
            Name = name;
        }

        
    }
}

