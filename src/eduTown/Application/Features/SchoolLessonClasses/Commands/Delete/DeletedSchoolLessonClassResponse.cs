using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolLessonClasses.Commands.Delete;

public class DeletedSchoolLessonClassResponse : IResponse
{
    public int Id { get; set; }
}