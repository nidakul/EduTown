using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserCertificateRepository : EfRepositoryBase<UserCertificate, int, BaseDbContext>, IUserCertificateRepository
{
    public UserCertificateRepository(BaseDbContext context) : base(context)
    {
    }
}