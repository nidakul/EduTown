using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class PostFile : Entity<int>
    {
        public int PostId { get; set; }
        public string FilePath { get; set; }

        public virtual Post Post { get; set; }

        public PostFile()
        {
        }
    }
}

