using NArchitecture.Core.Application.Responses;

namespace Application.Features.Users.Commands.Update;

public class UpdatedUserResponse : IResponse
{
    public Guid Id { get; set; }
    public string NationalIdentity { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }
    public string ImageUrl { get; set; }

    public UpdatedUserResponse()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        NationalIdentity = string.Empty;
        ImageUrl = string.Empty;
    }

    public UpdatedUserResponse(Guid id, string nationalIdentity, string firstName, string lastName, string email, bool status)
    {
        Id = id;
        NationalIdentity = nationalIdentity;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Status = status;
    }
}
