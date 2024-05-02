using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class City : Entity<int>
    {
        public string Name { get; set; }

        public City()
        {
        }
    }
}


