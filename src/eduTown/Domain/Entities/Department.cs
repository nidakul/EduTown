using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    //Deparment for Instructor. Like Fen, Mat 
    public class Department : Entity<int>
    {
        public string Name { get; set; }

        public Department()
        {
        }
    }
}


