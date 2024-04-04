using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class Gender : Entity<int>
    {
        public string Name { get; set; }
        public Gender()
        {
        }
    }
}

