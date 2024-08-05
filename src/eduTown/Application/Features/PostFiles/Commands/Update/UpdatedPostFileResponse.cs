using NArchitecture.Core.Application.Responses;

namespace Application.Features.PostFiles.Commands.Update;

public class UpdatedPostFileResponse : IResponse
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public string FilePath { get; set; }
}