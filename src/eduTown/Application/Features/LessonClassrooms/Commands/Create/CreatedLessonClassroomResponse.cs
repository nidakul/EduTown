using NArchitecture.Core.Application.Responses;

namespace Application.Features.LessonClassrooms.Commands.Create;

public class CreatedLessonClassroomResponse : IResponse
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public int ClassroomId { get; set; }
}