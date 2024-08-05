using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PostInteractionRepository : EfRepositoryBase<PostInteraction, int, BaseDbContext>, IPostInteractionRepository
{
    public PostInteractionRepository(BaseDbContext context) : base(context)
    {
    }
}