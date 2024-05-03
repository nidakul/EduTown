using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LessonClassrooms;

public interface ILessonClassroomService
{
    Task<LessonClassroom?> GetAsync(
        Expression<Func<LessonClassroom, bool>> predicate,
        Func<IQueryable<LessonClassroom>, IIncludableQueryable<LessonClassroom, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<LessonClassroom>?> GetListAsync(
        Expression<Func<LessonClassroom, bool>>? predicate = null,
        Func<IQueryable<LessonClassroom>, IOrderedQueryable<LessonClassroom>>? orderBy = null,
        Func<IQueryable<LessonClassroom>, IIncludableQueryable<LessonClassroom, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<LessonClassroom> AddAsync(LessonClassroom lessonClassroom);
    Task<LessonClassroom> UpdateAsync(LessonClassroom lessonClassroom);
    Task<LessonClassroom> DeleteAsync(LessonClassroom lessonClassroom, bool permanent = false);
}
