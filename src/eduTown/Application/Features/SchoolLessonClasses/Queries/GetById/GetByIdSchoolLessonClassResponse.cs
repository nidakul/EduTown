using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolLessonClasses.Queries.GetById;

public class GetByIdSchoolLessonClassResponse : IResponse
{
    public int Id { get; set; }
}