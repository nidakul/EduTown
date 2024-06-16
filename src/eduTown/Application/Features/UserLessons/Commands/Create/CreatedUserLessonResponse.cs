using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserLessons.Commands.Create;

public class CreatedUserLessonResponse : IResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int LessonId { get; set; }
}