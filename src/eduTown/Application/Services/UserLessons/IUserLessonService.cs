using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserLessons;

public interface IUserLessonService
{
    Task<UserLesson?> GetAsync(
        Expression<Func<UserLesson, bool>> predicate,
        Func<IQueryable<UserLesson>, IIncludableQueryable<UserLesson, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserLesson>?> GetListAsync(
        Expression<Func<UserLesson, bool>>? predicate = null,
        Func<IQueryable<UserLesson>, IOrderedQueryable<UserLesson>>? orderBy = null,
        Func<IQueryable<UserLesson>, IIncludableQueryable<UserLesson, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserLesson> AddAsync(UserLesson userLesson);
    Task<UserLesson> UpdateAsync(UserLesson userLesson);
    Task<UserLesson> DeleteAsync(UserLesson userLesson, bool permanent = false);
}
