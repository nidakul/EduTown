using NArchitecture.Core.Application.Responses;

namespace Application.Features.Terms.Queries.GetById;

public class GetByIdTermResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}