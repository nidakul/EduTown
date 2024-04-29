using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.GradeTypes;

public interface IGradeTypeService
{
    Task<GradeType?> GetAsync(
        Expression<Func<GradeType, bool>> predicate,
        Func<IQueryable<GradeType>, IIncludableQueryable<GradeType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<GradeType>?> GetListAsync(
        Expression<Func<GradeType, bool>>? predicate = null,
        Func<IQueryable<GradeType>, IOrderedQueryable<GradeType>>? orderBy = null,
        Func<IQueryable<GradeType>, IIncludableQueryable<GradeType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<GradeType> AddAsync(GradeType gradeType);
    Task<GradeType> UpdateAsync(GradeType gradeType);
    Task<GradeType> DeleteAsync(GradeType gradeType, bool permanent = false);
}
