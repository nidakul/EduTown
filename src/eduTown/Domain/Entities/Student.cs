using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class Student : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public string StudentNo { get; set; }
        public DateTime Birthdate { get; set; }
        public string Birthplace { get; set; }
        public string Branch { get; set; } //şube

        //public int CurrentYearLevel { get; set; } 

        public virtual User User { get; set; }

        public Student()
        {
        } 
    }
}
 


