using NArchitecture.Core.Application.Responses;

namespace Application.Features.GradeTypes.Commands.Delete;

public class DeletedGradeTypeResponse : IResponse
{
    public int Id { get; set; }
}