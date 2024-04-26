using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserCertificates.Commands.Update;

public class UpdatedUserCertificateResponse : IResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int CertificateId { get; set; }
    public int ClassroomId { get; set; }
    public DateTime Year { get; set; }
    public int Semester { get; set; }
}