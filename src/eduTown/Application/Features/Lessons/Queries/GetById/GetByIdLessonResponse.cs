using NArchitecture.Core.Application.Responses;

namespace Application.Features.Lessons.Queries.GetById;

public class GetByIdLessonResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}