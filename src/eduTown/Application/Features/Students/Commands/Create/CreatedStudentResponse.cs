using NArchitecture.Core.Application.Responses;

namespace Application.Features.Students.Commands.Create;

public class CreatedStudentResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public required string StudentNo { get; set; }
    public required int SchoolId { get; set; }
    public required int ClassroomId { get; set; }
    public required string NationalIdentity { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required DateTime Birthdate { get; set; }
    public required string Birthplace { get; set; }
    public required string Branch { get; set; }
    public string? ImageUrl { get; set; }
}
