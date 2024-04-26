using NArchitecture.Core.Application.Dtos;

namespace Application.Features.UserCertificates.Queries.GetList;

public class GetListUserCertificateListItemDto : IDto
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int CertificateId { get; set; }
    public int ClassroomId { get; set; }
    public DateTime Year { get; set; }
    public int Semester { get; set; }
}