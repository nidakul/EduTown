using NArchitecture.Core.Application.Responses;

namespace Application.Features.LessonClassrooms.Commands.Update;

public class UpdatedLessonClassroomResponse : IResponse
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public int ClassroomId { get; set; }
}