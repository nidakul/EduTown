using NArchitecture.Core.Application.Responses;

namespace Application.Features.Lessons.Commands.Update;

public class UpdatedLessonResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}