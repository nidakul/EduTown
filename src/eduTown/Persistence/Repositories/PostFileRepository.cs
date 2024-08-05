using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PostFileRepository : EfRepositoryBase<PostFile, int, BaseDbContext>, IPostFileRepository
{
    public PostFileRepository(BaseDbContext context) : base(context)
    {
    }
}