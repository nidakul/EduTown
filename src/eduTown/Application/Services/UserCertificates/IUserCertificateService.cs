using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserCertificates;

public interface IUserCertificateService
{
    Task<UserCertificate?> GetAsync(
        Expression<Func<UserCertificate, bool>> predicate,
        Func<IQueryable<UserCertificate>, IIncludableQueryable<UserCertificate, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserCertificate>?> GetListAsync(
        Expression<Func<UserCertificate, bool>>? predicate = null,
        Func<IQueryable<UserCertificate>, IOrderedQueryable<UserCertificate>>? orderBy = null,
        Func<IQueryable<UserCertificate>, IIncludableQueryable<UserCertificate, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserCertificate> AddAsync(UserCertificate userCertificate);
    Task<UserCertificate> UpdateAsync(UserCertificate userCertificate);
    Task<UserCertificate> DeleteAsync(UserCertificate userCertificate, bool permanent = false);
}
