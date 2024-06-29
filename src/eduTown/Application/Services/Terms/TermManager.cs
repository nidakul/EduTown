using Application.Features.Terms.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Terms;

public class TermManager : ITermService
{
    private readonly ITermRepository _termRepository;
    private readonly TermBusinessRules _termBusinessRules;

    public TermManager(ITermRepository termRepository, TermBusinessRules termBusinessRules)
    {
        _termRepository = termRepository;
        _termBusinessRules = termBusinessRules;
    }

    public async Task<Term?> GetAsync(
        Expression<Func<Term, bool>> predicate,
        Func<IQueryable<Term>, IIncludableQueryable<Term, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Term? term = await _termRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return term;
    }

    public async Task<IPaginate<Term>?> GetListAsync(
        Expression<Func<Term, bool>>? predicate = null,
        Func<IQueryable<Term>, IOrderedQueryable<Term>>? orderBy = null,
        Func<IQueryable<Term>, IIncludableQueryable<Term, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Term> termList = await _termRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return termList;
    }

    public async Task<Term> AddAsync(Term term)
    {
        Term addedTerm = await _termRepository.AddAsync(term);

        return addedTerm;
    }

    public async Task<Term> UpdateAsync(Term term)
    {
        Term updatedTerm = await _termRepository.UpdateAsync(term);

        return updatedTerm;
    }

    public async Task<Term> DeleteAsync(Term term, bool permanent = false)
    {
        Term deletedTerm = await _termRepository.DeleteAsync(term);

        return deletedTerm;
    }
}
