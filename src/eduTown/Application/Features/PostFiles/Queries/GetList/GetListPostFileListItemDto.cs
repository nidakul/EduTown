using NArchitecture.Core.Application.Dtos;

namespace Application.Features.PostFiles.Queries.GetList;

public class GetListPostFileListItemDto : IDto
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public string FilePath { get; set; }
}