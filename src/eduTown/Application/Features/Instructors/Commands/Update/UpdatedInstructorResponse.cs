using NArchitecture.Core.Application.Responses;

namespace Application.Features.Instructors.Commands.Update;

public class UpdatedInstructorResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Department { get; set; }
}