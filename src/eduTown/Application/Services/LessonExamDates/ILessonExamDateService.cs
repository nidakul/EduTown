using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LessonExamDates;

public interface ILessonExamDateService
{
    Task<LessonExamDate?> GetAsync(
        Expression<Func<LessonExamDate, bool>> predicate,
        Func<IQueryable<LessonExamDate>, IIncludableQueryable<LessonExamDate, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<LessonExamDate>?> GetListAsync(
        Expression<Func<LessonExamDate, bool>>? predicate = null,
        Func<IQueryable<LessonExamDate>, IOrderedQueryable<LessonExamDate>>? orderBy = null,
        Func<IQueryable<LessonExamDate>, IIncludableQueryable<LessonExamDate, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<LessonExamDate> AddAsync(LessonExamDate lessonExamDate);
    Task<LessonExamDate> UpdateAsync(LessonExamDate lessonExamDate);
    Task<LessonExamDate> DeleteAsync(LessonExamDate lessonExamDate, bool permanent = false);
}
