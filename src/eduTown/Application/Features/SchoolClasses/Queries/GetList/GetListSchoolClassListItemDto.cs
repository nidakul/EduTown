using NArchitecture.Core.Application.Dtos;

namespace Application.Features.SchoolClasses.Queries.GetList;

public class GetListSchoolClassListItemDto : IDto
{
    public int Id { get; set; }
    public int SchoolId { get; set; }
    public int ClassroomId { get; set; }
}