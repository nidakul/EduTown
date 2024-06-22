using NArchitecture.Core.Application.Responses;

namespace Application.Features.Lessons.Commands.Create;

public class CreatedLessonResponse : IResponse
{
    public int Id { get; set; }
    public int SchoolClassLessonId { get; set; }
    public string Name { get; set; }

} 