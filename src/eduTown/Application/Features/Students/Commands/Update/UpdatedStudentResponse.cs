using NArchitecture.Core.Application.Responses;

namespace Application.Features.Students.Commands.Update;

public class UpdatedStudentResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public int ClassroomId { get; set; }
    public string StudentNo { get; set; }
}