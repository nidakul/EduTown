using NArchitecture.Core.Application.Responses;

namespace Application.Features.LessonClassrooms.Commands.Delete;

public class DeletedLessonClassroomResponse : IResponse
{
    public int Id { get; set; }
}