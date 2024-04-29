using NArchitecture.Core.Application.Responses;

namespace Application.Features.StudentGradeLessons.Commands.Delete;

public class DeletedStudentGradeLessonResponse : IResponse
{
    public int Id { get; set; }
}