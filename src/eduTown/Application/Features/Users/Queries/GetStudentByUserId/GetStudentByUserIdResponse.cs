using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.Users.Queries.GetStudentByUserId
{
    public class GetStudentByUserIdResponse : IResponse
    {
        public Guid Id { get; set; }
        public string SchoolName { get; set; }
        public string NationalIdentity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string StudentNo { get; set; }
        public List<string> ClassroomName { get; set; }


        public GetStudentByUserIdResponse()
        {

        }

        public GetStudentByUserIdResponse(Guid id, string nationalIdentity, string firstName, string lastName, string email, string imageUrl, string studentNo, string schoolName, List<string> classroomName): this()
        {
            Id = id;
            NationalIdentity = nationalIdentity;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ImageUrl = imageUrl;
            StudentNo = studentNo;
            SchoolName = schoolName;
            ClassroomName = classroomName;
        }
    }
}


