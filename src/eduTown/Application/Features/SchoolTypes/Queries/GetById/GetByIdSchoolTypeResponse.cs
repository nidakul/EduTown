using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolTypes.Queries.GetById;

public class GetByIdSchoolTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}