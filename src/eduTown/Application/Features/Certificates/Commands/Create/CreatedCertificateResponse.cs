using NArchitecture.Core.Application.Responses;

namespace Application.Features.Certificates.Commands.Create;

public class CreatedCertificateResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}