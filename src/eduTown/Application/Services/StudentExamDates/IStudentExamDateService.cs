using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentExamDates;

public interface IStudentExamDateService
{
    Task<StudentExamDate?> GetAsync(
        Expression<Func<StudentExamDate, bool>> predicate,
        Func<IQueryable<StudentExamDate>, IIncludableQueryable<StudentExamDate, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<StudentExamDate>?> GetListAsync(
        Expression<Func<StudentExamDate, bool>>? predicate = null,
        Func<IQueryable<StudentExamDate>, IOrderedQueryable<StudentExamDate>>? orderBy = null,
        Func<IQueryable<StudentExamDate>, IIncludableQueryable<StudentExamDate, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<StudentExamDate> AddAsync(StudentExamDate studentExamDate);
    Task<StudentExamDate> UpdateAsync(StudentExamDate studentExamDate);
    Task<StudentExamDate> DeleteAsync(StudentExamDate studentExamDate, bool permanent = false);
}
