using NArchitecture.Core.Application.Dtos;

namespace Application.Features.InstructorDepartments.Queries.GetList;

public class GetListInstructorDepartmentListItemDto : IDto
{
    public int Id { get; set; }
    public int InstructorId { get; set; }
    public int DepartmentId { get; set; }
}