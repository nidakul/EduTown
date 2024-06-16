using NArchitecture.Core.Application.Dtos;

namespace Application.Features.StudentExamDates.Queries.GetList;

public class GetListStudentExamDateListItemDto : IDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int ExamDateId { get; set; }
}