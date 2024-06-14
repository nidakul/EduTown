using NArchitecture.Core.Application.Responses;

namespace Application.Features.Students.Commands.Create;

public class CreatedStudentResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string StudentNo { get; set; }
    public int SchoolId { get; set; }
    public int ClassroomId { get; set; }
    public string NationalIdentity { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime Birthdate { get; set; }
    public string Birthplace { get; set; }
    public string Branch { get; set; }
    public string? ImageUrl { get; set; }
}
