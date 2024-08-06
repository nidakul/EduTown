using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PostCommentRepository : EfRepositoryBase<PostComment, int, BaseDbContext>, IPostCommentRepository
{
    public PostCommentRepository(BaseDbContext context) : base(context)
    {
    }
}