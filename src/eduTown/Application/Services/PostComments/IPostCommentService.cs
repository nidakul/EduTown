using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PostComments;

public interface IPostCommentService
{
    Task<PostComment?> GetAsync(
        Expression<Func<PostComment, bool>> predicate,
        Func<IQueryable<PostComment>, IIncludableQueryable<PostComment, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<PostComment>?> GetListAsync(
        Expression<Func<PostComment, bool>>? predicate = null,
        Func<IQueryable<PostComment>, IOrderedQueryable<PostComment>>? orderBy = null,
        Func<IQueryable<PostComment>, IIncludableQueryable<PostComment, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<PostComment> AddAsync(PostComment postComment);
    Task<PostComment> UpdateAsync(PostComment postComment);
    Task<PostComment> DeleteAsync(PostComment postComment, bool permanent = false);
}
