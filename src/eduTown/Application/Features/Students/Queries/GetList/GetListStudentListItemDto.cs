using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Students.Queries.GetList;

public class GetListStudentListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string StudentNo { get; set; }
    public DateTime Birthdate { get; set; }
    public string Birthplace { get; set; }
    public string Branch { get; set; } //şube
}