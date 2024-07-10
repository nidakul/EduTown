using NArchitecture.Core.Application.Dtos;

namespace Application.Features.SchoolTypeClasses.Queries.GetList;

public class GetListSchoolTypeClassListItemDto : IDto
{
    public int Id { get; set; }
    public int SchoolTypeId { get; set; }
    public int ClassroomId { get; set; }
}