using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SchoolLessonClasses;

public interface ISchoolLessonClassService
{
    Task<SchoolLessonClass?> GetAsync(
        Expression<Func<SchoolLessonClass, bool>> predicate,
        Func<IQueryable<SchoolLessonClass>, IIncludableQueryable<SchoolLessonClass, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SchoolLessonClass>?> GetListAsync(
        Expression<Func<SchoolLessonClass, bool>>? predicate = null,
        Func<IQueryable<SchoolLessonClass>, IOrderedQueryable<SchoolLessonClass>>? orderBy = null,
        Func<IQueryable<SchoolLessonClass>, IIncludableQueryable<SchoolLessonClass, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SchoolLessonClass> AddAsync(SchoolLessonClass schoolLessonClass);
    Task<SchoolLessonClass> UpdateAsync(SchoolLessonClass schoolLessonClass);
    Task<SchoolLessonClass> DeleteAsync(SchoolLessonClass schoolLessonClass, bool permanent = false);
}
