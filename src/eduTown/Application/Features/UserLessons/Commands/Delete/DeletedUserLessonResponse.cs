using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserLessons.Commands.Delete;

public class DeletedUserLessonResponse : IResponse
{
    public int Id { get; set; }
}