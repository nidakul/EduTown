using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolClassLessons.Commands.Delete;

public class DeletedSchoolClassLessonResponse : IResponse
{
    public int Id { get; set; }
}