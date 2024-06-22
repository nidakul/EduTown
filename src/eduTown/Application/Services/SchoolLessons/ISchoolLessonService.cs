using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SchoolLessons;

public interface ISchoolLessonService
{
    Task<SchoolLesson?> GetAsync(
        Expression<Func<SchoolLesson, bool>> predicate,
        Func<IQueryable<SchoolLesson>, IIncludableQueryable<SchoolLesson, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SchoolLesson>?> GetListAsync(
        Expression<Func<SchoolLesson, bool>>? predicate = null,
        Func<IQueryable<SchoolLesson>, IOrderedQueryable<SchoolLesson>>? orderBy = null,
        Func<IQueryable<SchoolLesson>, IIncludableQueryable<SchoolLesson, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SchoolLesson> AddAsync(SchoolLesson schoolLesson);
    Task<SchoolLesson> UpdateAsync(SchoolLesson schoolLesson);
    Task<SchoolLesson> DeleteAsync(SchoolLesson schoolLesson, bool permanent = false);
}
