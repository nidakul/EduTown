using NArchitecture.Core.Application.Responses;

namespace Application.Features.ExamDates.Commands.Delete;

public class DeletedExamDateResponse : IResponse
{
    public int Id { get; set; }
}