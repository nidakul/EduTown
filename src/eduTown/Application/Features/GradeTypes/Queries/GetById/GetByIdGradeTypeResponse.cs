using NArchitecture.Core.Application.Responses;

namespace Application.Features.GradeTypes.Queries.GetById;

public class GetByIdGradeTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}