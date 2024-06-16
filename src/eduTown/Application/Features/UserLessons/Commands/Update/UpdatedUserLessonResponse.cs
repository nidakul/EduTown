using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserLessons.Commands.Update;

public class UpdatedUserLessonResponse : IResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int LessonId { get; set; }
}