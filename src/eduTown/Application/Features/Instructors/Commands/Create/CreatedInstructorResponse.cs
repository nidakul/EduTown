using NArchitecture.Core.Application.Responses;

namespace Application.Features.Instructors.Commands.Create;

public class CreatedInstructorResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Department { get; set; }
    public int SchoolId { get; set; }
    public int ClassroomId { get; set; }
    public string NationalIdentity { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? ImageUrl { get; set; }
}