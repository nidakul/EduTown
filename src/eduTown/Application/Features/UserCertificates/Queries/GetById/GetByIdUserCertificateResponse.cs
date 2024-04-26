using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserCertificates.Queries.GetById;

public class GetByIdUserCertificateResponse : IResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int CertificateId { get; set; }
    public int ClassroomId { get; set; }
    public DateTime Year { get; set; }
    public int Semester { get; set; }
}