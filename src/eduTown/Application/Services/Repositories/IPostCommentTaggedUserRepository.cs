using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPostCommentTaggedUserRepository : IAsyncRepository<PostCommentTaggedUser, int>, IRepository<PostCommentTaggedUser, int>
{
}