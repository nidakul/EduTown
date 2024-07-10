using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SchoolTypeClasses;

public interface ISchoolTypeClassService
{
    Task<SchoolTypeClass?> GetAsync(
        Expression<Func<SchoolTypeClass, bool>> predicate,
        Func<IQueryable<SchoolTypeClass>, IIncludableQueryable<SchoolTypeClass, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SchoolTypeClass>?> GetListAsync(
        Expression<Func<SchoolTypeClass, bool>>? predicate = null,
        Func<IQueryable<SchoolTypeClass>, IOrderedQueryable<SchoolTypeClass>>? orderBy = null,
        Func<IQueryable<SchoolTypeClass>, IIncludableQueryable<SchoolTypeClass, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SchoolTypeClass> AddAsync(SchoolTypeClass schoolTypeClass);
    Task<SchoolTypeClass> UpdateAsync(SchoolTypeClass schoolTypeClass);
    Task<SchoolTypeClass> DeleteAsync(SchoolTypeClass schoolTypeClass, bool permanent = false);
}
