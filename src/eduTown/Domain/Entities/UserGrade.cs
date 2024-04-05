using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class UserGrade : Entity<int>
    {
        public int GradeId { get; set; }
        public int UserId { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual User User { get; set; }

        public UserGrade()
        {
        }

        public UserGrade(int id, int gradeId, int userId): this()
        {
            Id = id;
            GradeId = gradeId;
            UserId = userId;
        }
    }
}

