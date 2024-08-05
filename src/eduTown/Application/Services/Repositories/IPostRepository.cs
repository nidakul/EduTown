using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPostRepository : IAsyncRepository<Post, int>, IRepository<Post, int>
{
}