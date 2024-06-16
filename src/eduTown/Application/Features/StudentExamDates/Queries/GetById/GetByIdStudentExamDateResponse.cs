using NArchitecture.Core.Application.Responses;

namespace Application.Features.StudentExamDates.Queries.GetById;

public class GetByIdStudentExamDateResponse : IResponse
{
    public int Id { get; set; }
    public Guid StudentId { get; set; }
    public int ExamDateId { get; set; }
}