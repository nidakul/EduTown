using Application.Features.PostInteractions.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PostInteractions;

public class PostInteractionManager : IPostInteractionService
{
    private readonly IPostInteractionRepository _postInteractionRepository;
    private readonly PostInteractionBusinessRules _postInteractionBusinessRules;

    public PostInteractionManager(IPostInteractionRepository postInteractionRepository, PostInteractionBusinessRules postInteractionBusinessRules)
    {
        _postInteractionRepository = postInteractionRepository;
        _postInteractionBusinessRules = postInteractionBusinessRules;
    }

    public async Task<PostInteraction?> GetAsync(
        Expression<Func<PostInteraction, bool>> predicate,
        Func<IQueryable<PostInteraction>, IIncludableQueryable<PostInteraction, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        PostInteraction? postInteraction = await _postInteractionRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return postInteraction;
    }

    public async Task<IPaginate<PostInteraction>?> GetListAsync(
        Expression<Func<PostInteraction, bool>>? predicate = null,
        Func<IQueryable<PostInteraction>, IOrderedQueryable<PostInteraction>>? orderBy = null,
        Func<IQueryable<PostInteraction>, IIncludableQueryable<PostInteraction, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<PostInteraction> postInteractionList = await _postInteractionRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return postInteractionList;
    }

    public async Task<PostInteraction> AddAsync(PostInteraction postInteraction)
    {
        PostInteraction addedPostInteraction = await _postInteractionRepository.AddAsync(postInteraction);

        return addedPostInteraction;
    }

    public async Task<PostInteraction> UpdateAsync(PostInteraction postInteraction)
    {
        PostInteraction updatedPostInteraction = await _postInteractionRepository.UpdateAsync(postInteraction);

        return updatedPostInteraction;
    }

    public async Task<PostInteraction> DeleteAsync(PostInteraction postInteraction, bool permanent = false)
    {
        PostInteraction deletedPostInteraction = await _postInteractionRepository.DeleteAsync(postInteraction);

        return deletedPostInteraction;
    }
}
