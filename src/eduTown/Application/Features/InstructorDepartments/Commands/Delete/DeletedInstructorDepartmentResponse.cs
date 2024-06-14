using NArchitecture.Core.Application.Responses;

namespace Application.Features.InstructorDepartments.Commands.Delete;

public class DeletedInstructorDepartmentResponse : IResponse
{
    public int Id { get; set; }
}