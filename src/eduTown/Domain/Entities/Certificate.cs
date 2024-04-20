using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class Certificate : Entity<int>
    {
        public string Name { get; set; }
        public Certificate()
        {
        }
    }
}

 