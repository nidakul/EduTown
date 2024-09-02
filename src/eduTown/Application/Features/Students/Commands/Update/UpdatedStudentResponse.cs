using NArchitecture.Core.Application.Responses;

namespace Application.Features.Students.Commands.Update;

public class UpdatedStudentResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public int BranchId { get; set; }
    public int ClassroomId { get; set; }
    public string StudentNo { get; set; }
    public string NationalIdentity { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateOnly Birthdate { get; set; }
    public string Birthplace { get; set; }
    public string? ImageUrl { get; set; }
}
