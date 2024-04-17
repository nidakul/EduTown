using NArchitecture.Core.Application.Responses;

namespace Application.Features.Students.Commands.Create;

public class CreatedStudentResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string StudentNo { get; set; }
}