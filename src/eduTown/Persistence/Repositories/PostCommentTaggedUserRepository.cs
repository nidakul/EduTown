using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PostCommentTaggedUserRepository : EfRepositoryBase<PostCommentTaggedUser, int, BaseDbContext>, IPostCommentTaggedUserRepository
{
    public PostCommentTaggedUserRepository(BaseDbContext context) : base(context)
    {
    }
}