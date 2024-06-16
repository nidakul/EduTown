using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ExamDates;

public interface IExamDateService
{
    Task<ExamDate?> GetAsync(
        Expression<Func<ExamDate, bool>> predicate,
        Func<IQueryable<ExamDate>, IIncludableQueryable<ExamDate, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ExamDate>?> GetListAsync(
        Expression<Func<ExamDate, bool>>? predicate = null,
        Func<IQueryable<ExamDate>, IOrderedQueryable<ExamDate>>? orderBy = null,
        Func<IQueryable<ExamDate>, IIncludableQueryable<ExamDate, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ExamDate> AddAsync(ExamDate examDate);
    Task<ExamDate> UpdateAsync(ExamDate examDate);
    Task<ExamDate> DeleteAsync(ExamDate examDate, bool permanent = false);
}
