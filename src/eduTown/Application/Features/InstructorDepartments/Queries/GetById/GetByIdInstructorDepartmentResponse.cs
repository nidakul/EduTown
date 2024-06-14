using NArchitecture.Core.Application.Responses;

namespace Application.Features.InstructorDepartments.Queries.GetById;

public class GetByIdInstructorDepartmentResponse : IResponse
{
    public int Id { get; set; }
    public int InstructorId { get; set; }
    public int DepartmentId { get; set; }
}