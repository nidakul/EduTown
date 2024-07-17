using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.Users.Queries.GetInstructorByUserId
{
    public class GetInstructorByUserIdResponse : IResponse
    {
        public Guid Id { get; set; }
        public string SchoolName { get; set; }
        public string NationalIdentity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string? ImageUrl { get; set; }

        public GetInstructorByUserIdResponse()
        {
        }

        public GetInstructorByUserIdResponse(Guid id, string schoolName, string nationalIdentity, string firstName, string lastName, string email, string gender, string? imageUrl): this()
        {
            Id = id;
            SchoolName = schoolName;
            NationalIdentity = nationalIdentity;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Gender = gender;
            ImageUrl = imageUrl;
        }
    }
}

