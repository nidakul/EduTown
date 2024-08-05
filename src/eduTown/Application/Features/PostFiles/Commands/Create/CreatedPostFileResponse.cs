using NArchitecture.Core.Application.Responses;

namespace Application.Features.PostFiles.Commands.Create;

public class CreatedPostFileResponse : IResponse
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public string FilePath { get; set; }
}