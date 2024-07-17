using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Students.Queries.GetList;

public class GetListStudentListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public int SchoolId { get; set; }
    public int BranchId { get; set; }
    public int ClassroomId { get; set; }
    public string StudentNo { get; set; }
    public string NationalIdentity { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime Birthdate { get; set; }
    public string Birthplace { get; set; }
    public string ImageUrl { get; set; }
}