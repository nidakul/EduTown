using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Certificates.Queries.GetList;

public class GetListCertificateListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}