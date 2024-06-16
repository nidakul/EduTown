using NArchitecture.Core.Application.Dtos;

namespace Application.Features.ExamDates.Queries.GetList;

public class GetListExamDateListItemDto : IDto
{
    public int Id { get; set; }
    public string ExamType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}