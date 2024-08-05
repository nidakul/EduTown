using Application.Features.PostFiles.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PostFiles;

public class PostFileManager : IPostFileService
{
    private readonly IPostFileRepository _postFileRepository;
    private readonly PostFileBusinessRules _postFileBusinessRules;

    public PostFileManager(IPostFileRepository postFileRepository, PostFileBusinessRules postFileBusinessRules)
    {
        _postFileRepository = postFileRepository;
        _postFileBusinessRules = postFileBusinessRules;
    }

    public async Task<PostFile?> GetAsync(
        Expression<Func<PostFile, bool>> predicate,
        Func<IQueryable<PostFile>, IIncludableQueryable<PostFile, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        PostFile? postFile = await _postFileRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return postFile;
    }

    public async Task<IPaginate<PostFile>?> GetListAsync(
        Expression<Func<PostFile, bool>>? predicate = null,
        Func<IQueryable<PostFile>, IOrderedQueryable<PostFile>>? orderBy = null,
        Func<IQueryable<PostFile>, IIncludableQueryable<PostFile, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<PostFile> postFileList = await _postFileRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return postFileList;
    }

    public async Task<PostFile> AddAsync(PostFile postFile)
    {
        PostFile addedPostFile = await _postFileRepository.AddAsync(postFile);

        return addedPostFile;
    }

    public async Task<PostFile> UpdateAsync(PostFile postFile)
    {
        PostFile updatedPostFile = await _postFileRepository.UpdateAsync(postFile);

        return updatedPostFile;
    }

    public async Task<PostFile> DeleteAsync(PostFile postFile, bool permanent = false)
    {
        PostFile deletedPostFile = await _postFileRepository.DeleteAsync(postFile);

        return deletedPostFile;
    }
}
