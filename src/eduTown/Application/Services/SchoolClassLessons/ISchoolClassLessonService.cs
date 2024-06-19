using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SchoolClassLessons;

public interface ISchoolClassLessonService
{
    Task<SchoolClassLesson?> GetAsync(
        Expression<Func<SchoolClassLesson, bool>> predicate,
        Func<IQueryable<SchoolClassLesson>, IIncludableQueryable<SchoolClassLesson, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SchoolClassLesson>?> GetListAsync(
        Expression<Func<SchoolClassLesson, bool>>? predicate = null,
        Func<IQueryable<SchoolClassLesson>, IOrderedQueryable<SchoolClassLesson>>? orderBy = null,
        Func<IQueryable<SchoolClassLesson>, IIncludableQueryable<SchoolClassLesson, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SchoolClassLesson> AddAsync(SchoolClassLesson schoolClassLesson);
    Task<SchoolClassLesson> UpdateAsync(SchoolClassLesson schoolClassLesson);
    Task<SchoolClassLesson> DeleteAsync(SchoolClassLesson schoolClassLesson, bool permanent = false);
}
