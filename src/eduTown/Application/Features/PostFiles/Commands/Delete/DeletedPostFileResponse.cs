using NArchitecture.Core.Application.Responses;

namespace Application.Features.PostFiles.Commands.Delete;

public class DeletedPostFileResponse : IResponse
{
    public int Id { get; set; }
}