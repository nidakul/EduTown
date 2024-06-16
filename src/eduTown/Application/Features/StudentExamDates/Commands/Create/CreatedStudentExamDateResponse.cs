using NArchitecture.Core.Application.Responses;

namespace Application.Features.StudentExamDates.Commands.Create;

public class CreatedStudentExamDateResponse : IResponse
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int ExamDateId { get; set; }
}