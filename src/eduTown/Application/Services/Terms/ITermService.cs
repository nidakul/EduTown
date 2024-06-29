using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Terms;

public interface ITermService
{
    Task<Term?> GetAsync(
        Expression<Func<Term, bool>> predicate,
        Func<IQueryable<Term>, IIncludableQueryable<Term, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Term>?> GetListAsync(
        Expression<Func<Term, bool>>? predicate = null,
        Func<IQueryable<Term>, IOrderedQueryable<Term>>? orderBy = null,
        Func<IQueryable<Term>, IIncludableQueryable<Term, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Term> AddAsync(Term term);
    Task<Term> UpdateAsync(Term term);
    Task<Term> DeleteAsync(Term term, bool permanent = false);
}
