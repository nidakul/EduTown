using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class Certificate : Entity<int>
    {
        public int GradeId { get; set; }
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public int Semester { get; set; }

        public virtual Grade Grade { get; set; }
        public Certificate()
        {
        }

        public Certificate(int gradeId, string name, DateTime year, int semester)
        {
            GradeId = gradeId;
            Name = name;
            Year = year;
            Semester = semester;
        }

        

    }
}


