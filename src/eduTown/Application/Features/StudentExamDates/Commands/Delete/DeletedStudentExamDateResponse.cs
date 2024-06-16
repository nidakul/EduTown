using NArchitecture.Core.Application.Responses;

namespace Application.Features.StudentExamDates.Commands.Delete;

public class DeletedStudentExamDateResponse : IResponse
{
    public int Id { get; set; }
}