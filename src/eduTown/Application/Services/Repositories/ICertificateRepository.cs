using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICertificateRepository : IAsyncRepository<Certificate, int>, IRepository<Certificate, int>
{
}