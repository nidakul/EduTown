using NArchitecture.Core.Application.Dtos;

namespace Application.Features.SchoolClassLessons.Queries.GetList;

public class GetListSchoolClassLessonListItemDto : IDto
{
    public int Id { get; set; }
    public int SchoolClassroomId { get; set; }
    public int LessonId { get; set; }
}