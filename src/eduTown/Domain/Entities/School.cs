using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class School: Entity<int>
    {
        public string Name { get; set; }

        public School()
        {
        }

        public School(int id, string name): this()
        {
            Id = id;
            Name = name;
        }
    }
}


