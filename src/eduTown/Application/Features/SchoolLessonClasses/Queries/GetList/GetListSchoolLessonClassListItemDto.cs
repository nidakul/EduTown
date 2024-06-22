using NArchitecture.Core.Application.Dtos;

namespace Application.Features.SchoolLessonClasses.Queries.GetList;

public class GetListSchoolLessonClassListItemDto : IDto
{
    public int Id { get; set; }
}