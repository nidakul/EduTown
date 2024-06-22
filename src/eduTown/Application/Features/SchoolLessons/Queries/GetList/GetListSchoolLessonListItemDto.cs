using NArchitecture.Core.Application.Dtos;

namespace Application.Features.SchoolLessons.Queries.GetList;

public class GetListSchoolLessonListItemDto : IDto
{
    public int Id { get; set; }
    public int SchoolId { get; set; }
    public int LessonId { get; set; }
}