using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolLessonClasses.Commands.Create;

public class CreatedSchoolLessonClassResponse : IResponse
{
    public int Id { get; set; }
}