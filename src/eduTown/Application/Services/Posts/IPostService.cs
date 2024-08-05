using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Posts;

public interface IPostService
{
    Task<Post?> GetAsync(
        Expression<Func<Post, bool>> predicate,
        Func<IQueryable<Post>, IIncludableQueryable<Post, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Post>?> GetListAsync(
        Expression<Func<Post, bool>>? predicate = null,
        Func<IQueryable<Post>, IOrderedQueryable<Post>>? orderBy = null,
        Func<IQueryable<Post>, IIncludableQueryable<Post, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Post> AddAsync(Post post);
    Task<Post> UpdateAsync(Post post);
    Task<Post> DeleteAsync(Post post, bool permanent = false);
}
