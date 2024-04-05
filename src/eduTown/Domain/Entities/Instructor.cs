using NArchitecture.Core.Persistence.Repositories;
using Domain.Entities;
using System;
namespace Domain.Entities
{
    public class Instructor : Entity<int>
    {
        public int SchoolId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Country Country { get; set; }
        public virtual School School { get; set; }
        public virtual City City { get; set; }
        public virtual District District { get; set; }

        public virtual ICollection<UserInstructor> UserInstructors { get; set; }

        public Instructor()
        {
        }

        public Instructor(int id, int schoolId, int countryId, int cityId, int districtId, string firstName, string lastName) : this()
        {
            Id = id;
            SchoolId = schoolId;
            CountryId = countryId;
            CityId = cityId;
            DistrictId = districtId;
            FirstName = firstName;
            LastName = lastName;
        }

        

    }
}

