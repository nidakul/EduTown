using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPostCommentRepository : IAsyncRepository<PostComment, int>, IRepository<PostComment, int>
{
}