using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserLessons.Queries.GetById;

public class GetByIdUserLessonResponse : IResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int LessonId { get; set; }
}