using Application.Features.PostComments.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PostComments;

public class PostCommentManager : IPostCommentService
{
    private readonly IPostCommentRepository _postCommentRepository;
    private readonly PostCommentBusinessRules _postCommentBusinessRules;

    public PostCommentManager(IPostCommentRepository postCommentRepository, PostCommentBusinessRules postCommentBusinessRules)
    {
        _postCommentRepository = postCommentRepository;
        _postCommentBusinessRules = postCommentBusinessRules;
    }

    public async Task<PostComment?> GetAsync(
        Expression<Func<PostComment, bool>> predicate,
        Func<IQueryable<PostComment>, IIncludableQueryable<PostComment, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        PostComment? postComment = await _postCommentRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return postComment;
    }

    public async Task<IPaginate<PostComment>?> GetListAsync(
        Expression<Func<PostComment, bool>>? predicate = null,
        Func<IQueryable<PostComment>, IOrderedQueryable<PostComment>>? orderBy = null,
        Func<IQueryable<PostComment>, IIncludableQueryable<PostComment, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<PostComment> postCommentList = await _postCommentRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return postCommentList;
    }

    public async Task<PostComment> AddAsync(PostComment postComment)
    {
        PostComment addedPostComment = await _postCommentRepository.AddAsync(postComment);

        return addedPostComment;
    }

    public async Task<PostComment> UpdateAsync(PostComment postComment)
    {
        PostComment updatedPostComment = await _postCommentRepository.UpdateAsync(postComment);

        return updatedPostComment;
    }

    public async Task<PostComment> DeleteAsync(PostComment postComment, bool permanent = false)
    {
        PostComment deletedPostComment = await _postCommentRepository.DeleteAsync(postComment);

        return deletedPostComment;
    }
}
