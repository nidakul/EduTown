using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolLessons.Commands.Delete;

public class DeletedSchoolLessonResponse : IResponse
{
    public int Id { get; set; }
}