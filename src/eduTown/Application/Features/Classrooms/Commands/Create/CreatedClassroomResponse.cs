using NArchitecture.Core.Application.Responses;

namespace Application.Features.Classrooms.Commands.Create;

public class CreatedClassroomResponse : IResponse
{
    public int Id { get; set; }
    public int SchoolLessonId { get; set; }
    public string Name { get; set; }
}