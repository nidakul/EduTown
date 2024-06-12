using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SchoolTypes;

public interface ISchoolTypeService
{
    Task<SchoolType?> GetAsync(
        Expression<Func<SchoolType, bool>> predicate,
        Func<IQueryable<SchoolType>, IIncludableQueryable<SchoolType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SchoolType>?> GetListAsync(
        Expression<Func<SchoolType, bool>>? predicate = null,
        Func<IQueryable<SchoolType>, IOrderedQueryable<SchoolType>>? orderBy = null,
        Func<IQueryable<SchoolType>, IIncludableQueryable<SchoolType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SchoolType> AddAsync(SchoolType schoolType);
    Task<SchoolType> UpdateAsync(SchoolType schoolType);
    Task<SchoolType> DeleteAsync(SchoolType schoolType, bool permanent = false);
}
