using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SchoolClassBranches;

public interface ISchoolClassBranchService
{
    Task<SchoolClassBranch?> GetAsync(
        Expression<Func<SchoolClassBranch, bool>> predicate,
        Func<IQueryable<SchoolClassBranch>, IIncludableQueryable<SchoolClassBranch, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SchoolClassBranch>?> GetListAsync(
        Expression<Func<SchoolClassBranch, bool>>? predicate = null,
        Func<IQueryable<SchoolClassBranch>, IOrderedQueryable<SchoolClassBranch>>? orderBy = null,
        Func<IQueryable<SchoolClassBranch>, IIncludableQueryable<SchoolClassBranch, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SchoolClassBranch> AddAsync(SchoolClassBranch schoolClassBranch);
    Task<SchoolClassBranch> UpdateAsync(SchoolClassBranch schoolClassBranch);
    Task<SchoolClassBranch> DeleteAsync(SchoolClassBranch schoolClassBranch, bool permanent = false);
}
