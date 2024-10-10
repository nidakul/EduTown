using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PostCommentTaggedUsers;

public interface IPostCommentTaggedUserService
{
    Task<PostCommentTaggedUser?> GetAsync(
        Expression<Func<PostCommentTaggedUser, bool>> predicate,
        Func<IQueryable<PostCommentTaggedUser>, IIncludableQueryable<PostCommentTaggedUser, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<PostCommentTaggedUser>?> GetListAsync(
        Expression<Func<PostCommentTaggedUser, bool>>? predicate = null,
        Func<IQueryable<PostCommentTaggedUser>, IOrderedQueryable<PostCommentTaggedUser>>? orderBy = null,
        Func<IQueryable<PostCommentTaggedUser>, IIncludableQueryable<PostCommentTaggedUser, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<PostCommentTaggedUser> AddAsync(PostCommentTaggedUser postCommentTaggedUser);
    Task<PostCommentTaggedUser> UpdateAsync(PostCommentTaggedUser postCommentTaggedUser);
    Task<PostCommentTaggedUser> DeleteAsync(PostCommentTaggedUser postCommentTaggedUser, bool permanent = false);
}
