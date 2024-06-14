using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.Users.Queries.GetInstructorByUserId
{
    public class GetInstructorByUserIdResponse : IResponse
    {
        public Guid Id { get; set; }
        public int SchoolId { get; set; }
        public string NationalIdentity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? ImageUrl { get; set; }
        public string Department { get; set; }

        public GetInstructorByUserIdResponse()
        {
        }

        public GetInstructorByUserIdResponse(Guid id, int schoolId, string nationalIdentity, string firstName, string lastName, string email, string? imageUrl, string department): this()
        {
            Id = id;
            SchoolId = schoolId;
            NationalIdentity = nationalIdentity;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ImageUrl = imageUrl;
            Department = department;
        }
    }
}

