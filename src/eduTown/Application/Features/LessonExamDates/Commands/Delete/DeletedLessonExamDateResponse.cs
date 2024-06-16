using NArchitecture.Core.Application.Responses;

namespace Application.Features.LessonExamDates.Commands.Delete;

public class DeletedLessonExamDateResponse : IResponse
{
    public int Id { get; set; }
}