using NArchitecture.Core.Application.Responses;

namespace Application.Features.Students.Queries.GetById;

public class GetByIdStudentResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string StudentNo { get; set; }
}