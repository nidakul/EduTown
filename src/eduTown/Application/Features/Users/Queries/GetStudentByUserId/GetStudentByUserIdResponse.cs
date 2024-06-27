using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.Users.Queries.GetStudentByUserId
{
    public class GetStudentByUserIdResponse : IResponse
    {
        public Guid Id { get; set; }
        public int SchoolId { get; set; }
        public int ClassroomId { get; set; }
        public string SchoolName { get; set; }
        public string NationalIdentity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string StudentNo { get; set; }
        public string Gender { get; set; }
        public string ClassroomName { get; set; }


        public GetStudentByUserIdResponse()
        {

        }

        public GetStudentByUserIdResponse(Guid id, int schoolId, int classroomId, string schoolName, string nationalIdentity, string firstName, string lastName, string email, string imageUrl, string studentNo, string gender, string classroomName): this()
        {
            Id = id;
            SchoolId = schoolId;
            ClassroomId = classroomId;
            SchoolName = schoolName;
            NationalIdentity = nationalIdentity;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ImageUrl = imageUrl;
            StudentNo = studentNo;
            Gender = gender;
            ClassroomName = classroomName;
        }
    }
}



