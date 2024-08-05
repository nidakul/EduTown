using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PostFiles;

public interface IPostFileService
{
    Task<PostFile?> GetAsync(
        Expression<Func<PostFile, bool>> predicate,
        Func<IQueryable<PostFile>, IIncludableQueryable<PostFile, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<PostFile>?> GetListAsync(
        Expression<Func<PostFile, bool>>? predicate = null,
        Func<IQueryable<PostFile>, IOrderedQueryable<PostFile>>? orderBy = null,
        Func<IQueryable<PostFile>, IIncludableQueryable<PostFile, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<PostFile> AddAsync(PostFile postFile);
    Task<PostFile> UpdateAsync(PostFile postFile);
    Task<PostFile> DeleteAsync(PostFile postFile, bool permanent = false);
}
