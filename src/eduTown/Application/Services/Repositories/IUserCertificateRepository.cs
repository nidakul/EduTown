using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserCertificateRepository : IAsyncRepository<UserCertificate, int>, IRepository<UserCertificate, int>
{
}