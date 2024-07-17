using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.Students.Queries.GetStudentDetail
{
    public class GetListStudentDetailResponse : IResponse
    {
        public Guid Id { get; set; }
        public int SchoolId { get; set; }
        public int ClassroomId { get; set; }
        public int BranchId { get; set; }
        public string SchoolName { get; set; }
        public string BranchName { get; set; }
        public string NationalIdentity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string StudentNo { get; set; }
        public string Gender { get; set; }
        public string ClassroomName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Birthplace { get; set; }

        public GetListStudentDetailResponse()
        {
        }

        public GetListStudentDetailResponse(Guid id, int schoolId, int classroomId, int branchId, string schoolName, string branchName, string nationalIdentity, string firstName, string lastName, string email, string imageUrl, string studentNo, string gender, string classroomName, DateTime birthdate, string birthplace): this()
        {
            Id = id;
            SchoolId = schoolId;
            ClassroomId = classroomId;
            BranchId = branchId;
            SchoolName = schoolName;
            BranchName = branchName;
            NationalIdentity = nationalIdentity;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ImageUrl = imageUrl;
            StudentNo = studentNo;
            Gender = gender;
            ClassroomName = classroomName;
            Birthdate = birthdate;
            Birthplace = birthplace;
        }
    }
}



