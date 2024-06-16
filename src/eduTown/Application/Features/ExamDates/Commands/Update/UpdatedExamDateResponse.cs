using NArchitecture.Core.Application.Responses;

namespace Application.Features.ExamDates.Commands.Update;

public class UpdatedExamDateResponse : IResponse
{
    public int Id { get; set; }
    public string ExamType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}