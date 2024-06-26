using NArchitecture.Core.Application.Responses;

namespace Application.Features.StudentExamDates.Commands.Update;

public class UpdatedStudentExamDateResponse : IResponse
{
    public int Id { get; set; }
    public Guid StudentId { get; set; }
    public int ExamDateId { get; set; }
}