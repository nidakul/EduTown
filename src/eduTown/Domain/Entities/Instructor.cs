using NArchitecture.Core.Persistence.Repositories;
using Domain.Entities;
using System;
namespace Domain.Entities
{
    public class Instructor : Entity<int>
    {
        public Instructor()
        {
        }

        public Instructor(int studentId, int courseId, int schoolId, int countryId, int cityId, int districtId, string firstName, string lastName)
        {
            StudentId = studentId;
            SchoolId = schoolId;
            CountryId = countryId;
            CityId = cityId;
            DistrictId = districtId;
            FirstName = firstName;
            LastName = lastName;
        }

        public int StudentId { get; set; }
        public int SchoolId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Country Country { get; set; }
        public virtual School School { get; set; }
        public virtual Student Student { get; set; }
        public virtual City City { get; set; }
        public virtual District District { get; set; }


    }
}

