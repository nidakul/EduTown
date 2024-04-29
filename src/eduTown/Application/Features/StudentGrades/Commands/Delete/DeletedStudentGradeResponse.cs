using NArchitecture.Core.Application.Responses;

namespace Application.Features.StudentGrades.Commands.Delete;

public class DeletedStudentGradeResponse : IResponse
{
    public int Id { get; set; }
}