using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserCertificates.Commands.Delete;

public class DeletedUserCertificateResponse : IResponse
{
    public int Id { get; set; }
}