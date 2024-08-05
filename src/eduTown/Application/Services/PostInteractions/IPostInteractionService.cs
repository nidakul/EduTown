using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PostInteractions;

public interface IPostInteractionService
{
    Task<PostInteraction?> GetAsync(
        Expression<Func<PostInteraction, bool>> predicate,
        Func<IQueryable<PostInteraction>, IIncludableQueryable<PostInteraction, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<PostInteraction>?> GetListAsync(
        Expression<Func<PostInteraction, bool>>? predicate = null,
        Func<IQueryable<PostInteraction>, IOrderedQueryable<PostInteraction>>? orderBy = null,
        Func<IQueryable<PostInteraction>, IIncludableQueryable<PostInteraction, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<PostInteraction> AddAsync(PostInteraction postInteraction);
    Task<PostInteraction> UpdateAsync(PostInteraction postInteraction);
    Task<PostInteraction> DeleteAsync(PostInteraction postInteraction, bool permanent = false);
}
