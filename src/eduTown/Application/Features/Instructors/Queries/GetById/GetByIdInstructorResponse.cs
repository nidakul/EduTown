using NArchitecture.Core.Application.Responses;

namespace Application.Features.Instructors.Queries.GetById;

public class GetByIdInstructorResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Department { get; set; }
}