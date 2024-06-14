using NArchitecture.Core.Application.Responses;

namespace Application.Features.InstructorDepartments.Commands.Create;

public class CreatedInstructorDepartmentResponse : IResponse
{
    public int Id { get; set; }
    public int InstructorId { get; set; }
    public int DepartmentId { get; set; }
}