﻿using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class Classroom : Entity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<SchoolClass> SchoolClasses { get; set; }
        public virtual ICollection<UserCertificate> UserCertificates { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
        public virtual ICollection<SchoolTypeClass> SchoolTypeClasses { get; set; }


        public Classroom()
        {
        } 
    } 
}
 

 
 