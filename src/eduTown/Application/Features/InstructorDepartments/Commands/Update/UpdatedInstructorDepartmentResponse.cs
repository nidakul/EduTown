using NArchitecture.Core.Application.Responses;

namespace Application.Features.InstructorDepartments.Commands.Update;

public class UpdatedInstructorDepartmentResponse : IResponse
{
    public int Id { get; set; }
    public int InstructorId { get; set; }
    public int DepartmentId { get; set; }
}