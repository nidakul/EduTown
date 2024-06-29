using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    //Dönem bilgisi
    public class Term : Entity<int>
    {
        public string Name { get; set; }

        public Term()
        {
        }
    }
}

