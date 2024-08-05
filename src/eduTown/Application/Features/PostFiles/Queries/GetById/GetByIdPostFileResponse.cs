using NArchitecture.Core.Application.Responses;

namespace Application.Features.PostFiles.Queries.GetById;

public class GetByIdPostFileResponse : IResponse
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public string FilePath { get; set; }
}