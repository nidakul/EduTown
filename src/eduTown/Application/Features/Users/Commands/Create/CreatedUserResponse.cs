using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Users.Commands.Create;

public class CreatedUserResponse : IResponse
{
    public Guid Id { get; set; }
    public int SchoolId { get; set; }
    public int ClassroomId { get; set; }
    public string NationalIdentity { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }
    public string ImageUrl { get; set; }

    public CreatedUserResponse()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
    }

    public CreatedUserResponse(Guid id, int schoolId, int classroomId, string nationalIdentity, string firstName, string lastName, string email, bool status, string imageUrl):this()
    {
        Id = id;
        SchoolId = schoolId;
        ClassroomId = classroomId;
        NationalIdentity = nationalIdentity;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Status = status;
        ImageUrl = imageUrl;
    }
}
