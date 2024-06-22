﻿using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    //Okuldaki dersler hangi sınıfa ait
    public class SchoolLessonClass : Entity<int>
    {
        public int SchoolLessonId { get; set; }

        public virtual ICollection<Classroom> Classrooms{ get; set; }
        public SchoolLessonClass()
        {
        }
    }
}


