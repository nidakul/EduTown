using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.Users.Queries.GetCertificatesByUserId
{
    public class GetCertificatesByUserIdResponse : IResponse
    {
        
        public Guid Id { get; set; }
        public List<CertificateDto> Certificates { get; set; }

        public GetCertificatesByUserIdResponse()
        {
        }

    }


    public class CertificateDto
    {
        public int Id { get; set; }
        public string CertificateName { get; set; }
        public string ClassroomName { get; set; }
    }

}

