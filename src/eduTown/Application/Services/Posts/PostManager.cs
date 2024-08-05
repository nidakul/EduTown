using Application.Features.Posts.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Posts;

public class PostManager : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly PostBusinessRules _postBusinessRules;

    public PostManager(IPostRepository postRepository, PostBusinessRules postBusinessRules)
    {
        _postRepository = postRepository;
        _postBusinessRules = postBusinessRules;
    }

    public async Task<Post?> GetAsync(
        Expression<Func<Post, bool>> predicate,
        Func<IQueryable<Post>, IIncludableQueryable<Post, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Post? post = await _postRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return post;
    }

    public async Task<IPaginate<Post>?> GetListAsync(
        Expression<Func<Post, bool>>? predicate = null,
        Func<IQueryable<Post>, IOrderedQueryable<Post>>? orderBy = null,
        Func<IQueryable<Post>, IIncludableQueryable<Post, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Post> postList = await _postRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return postList;
    }

    public async Task<Post> AddAsync(Post post)
    {
        Post addedPost = await _postRepository.AddAsync(post);

        return addedPost;
    }

    public async Task<Post> UpdateAsync(Post post)
    {
        Post updatedPost = await _postRepository.UpdateAsync(post);

        return updatedPost;
    }

    public async Task<Post> DeleteAsync(Post post, bool permanent = false)
    {
        Post deletedPost = await _postRepository.DeleteAsync(post);

        return deletedPost;
    }
}
