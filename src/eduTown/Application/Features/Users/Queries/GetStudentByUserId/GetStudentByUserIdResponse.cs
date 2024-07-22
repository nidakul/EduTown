using Domain.Entities;
using NArchitecture.Core.Application.Dtos;
using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.Users.Queries.GetStudentByUserId
{
    public class GetStudentByUserIdResponse : IResponse
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public int SchoolId { get; set; }
        public int BranchId { get; set; }
        public int ClassroomId { get; set; }
        public string SchoolName { get; set; }
        public string BranchName { get; set; }
        public string ClassroomName { get; set; }
        public string NationalIdentity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string StudentNo { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string Birthplace { get; set; }

        public GetStudentByUserIdResponse()
        {

        }
    }
}



