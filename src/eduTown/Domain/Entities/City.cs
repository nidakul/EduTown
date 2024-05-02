using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class City : Entity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<School> Schools { get; set; }

        public City()
        {
        }
    }
}




