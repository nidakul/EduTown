using NArchitecture.Core.Application.Responses;

namespace Application.Features.ExamDates.Commands.Create;

public class CreatedExamDateResponse : IResponse
{
    public int Id { get; set; }
    public string ExamType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}