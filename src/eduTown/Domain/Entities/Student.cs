using NArchitecture.Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class Student : Entity<int>
    {
        public Guid UserId { get; set; }
        public int GradeId { get; set; }
        public int InstructorId { get; set; } 
        public int SchoolId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int BookId { get; set; }
        public int ExamId { get; set; }

        public int ClassId { get; set; }

        public string NationalIdentity { get; set; }
        public int  StudentNo { get; set; }
        public string ImageUrl { get; set; }
        public string SchoolName { get; set; }

        public virtual School School { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual User User { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual Country Country { get; set; }
        public virtual City City { get; set; }
        public virtual District District { get; set; }
        public virtual Book Book { get; set; }
        public virtual Exam Exams { get; set; }

        public virtual Class Class { get; set; }

        public Student()
        {
        }

        public Student(Guid userId, int gradeId, int instructorId, int schoolId, int countryId, int cityId, int districtId, int bookId, int examId, string nationalIdentity, int studentNo, string imageUrl, string schoolName)
        {
            UserId = userId;
            GradeId = gradeId;
            InstructorId = instructorId;
            SchoolId = schoolId;
            CountryId = countryId;
            CityId = cityId;
            DistrictId = districtId;
            BookId = bookId;
            ExamId = examId;
            NationalIdentity = nationalIdentity;
            StudentNo = studentNo;
            ImageUrl = imageUrl;
            SchoolName = schoolName;
        }
    }
}


