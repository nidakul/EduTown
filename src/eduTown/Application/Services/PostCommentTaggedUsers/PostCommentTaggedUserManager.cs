using Application.Features.PostCommentTaggedUsers.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PostCommentTaggedUsers;

public class PostCommentTaggedUserManager : IPostCommentTaggedUserService
{
    private readonly IPostCommentTaggedUserRepository _postCommentTaggedUserRepository;
    private readonly PostCommentTaggedUserBusinessRules _postCommentTaggedUserBusinessRules;

    public PostCommentTaggedUserManager(IPostCommentTaggedUserRepository postCommentTaggedUserRepository, PostCommentTaggedUserBusinessRules postCommentTaggedUserBusinessRules)
    {
        _postCommentTaggedUserRepository = postCommentTaggedUserRepository;
        _postCommentTaggedUserBusinessRules = postCommentTaggedUserBusinessRules;
    }

    public async Task<PostCommentTaggedUser?> GetAsync(
        Expression<Func<PostCommentTaggedUser, bool>> predicate,
        Func<IQueryable<PostCommentTaggedUser>, IIncludableQueryable<PostCommentTaggedUser, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        PostCommentTaggedUser? postCommentTaggedUser = await _postCommentTaggedUserRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return postCommentTaggedUser;
    }

    public async Task<IPaginate<PostCommentTaggedUser>?> GetListAsync(
        Expression<Func<PostCommentTaggedUser, bool>>? predicate = null,
        Func<IQueryable<PostCommentTaggedUser>, IOrderedQueryable<PostCommentTaggedUser>>? orderBy = null,
        Func<IQueryable<PostCommentTaggedUser>, IIncludableQueryable<PostCommentTaggedUser, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<PostCommentTaggedUser> postCommentTaggedUserList = await _postCommentTaggedUserRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return postCommentTaggedUserList;
    }

    public async Task<PostCommentTaggedUser> AddAsync(PostCommentTaggedUser postCommentTaggedUser)
    {
        PostCommentTaggedUser addedPostCommentTaggedUser = await _postCommentTaggedUserRepository.AddAsync(postCommentTaggedUser);

        return addedPostCommentTaggedUser;
    }

    public async Task<PostCommentTaggedUser> UpdateAsync(PostCommentTaggedUser postCommentTaggedUser)
    {
        PostCommentTaggedUser updatedPostCommentTaggedUser = await _postCommentTaggedUserRepository.UpdateAsync(postCommentTaggedUser);

        return updatedPostCommentTaggedUser;
    }

    public async Task<PostCommentTaggedUser> DeleteAsync(PostCommentTaggedUser postCommentTaggedUser, bool permanent = false)
    {
        PostCommentTaggedUser deletedPostCommentTaggedUser = await _postCommentTaggedUserRepository.DeleteAsync(postCommentTaggedUser);

        return deletedPostCommentTaggedUser;
    }
}
