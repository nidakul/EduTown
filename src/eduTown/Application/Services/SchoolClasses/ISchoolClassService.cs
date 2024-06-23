using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SchoolClasses;

public interface ISchoolClassService
{
    Task<SchoolClass?> GetAsync(
        Expression<Func<SchoolClass, bool>> predicate,
        Func<IQueryable<SchoolClass>, IIncludableQueryable<SchoolClass, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SchoolClass>?> GetListAsync(
        Expression<Func<SchoolClass, bool>>? predicate = null,
        Func<IQueryable<SchoolClass>, IOrderedQueryable<SchoolClass>>? orderBy = null,
        Func<IQueryable<SchoolClass>, IIncludableQueryable<SchoolClass, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SchoolClass> AddAsync(SchoolClass schoolClass);
    Task<SchoolClass> UpdateAsync(SchoolClass schoolClass);
    Task<SchoolClass> DeleteAsync(SchoolClass schoolClass, bool permanent = false);
}
