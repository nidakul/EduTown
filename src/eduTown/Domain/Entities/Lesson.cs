using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Xml.Linq;

namespace Domain.Entities
{
    public class Lesson : Entity<int>
    {
        public string Name { get; set; }
        public int Hour { get; set; }
        public Lesson()
        {
        }
    }
}

