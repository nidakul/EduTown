using NArchitecture.Core.Application.Responses;

namespace Application.Features.LessonClassrooms.Queries.GetById;

public class GetByIdLessonClassroomResponse : IResponse
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public int ClassroomId { get; set; }
}