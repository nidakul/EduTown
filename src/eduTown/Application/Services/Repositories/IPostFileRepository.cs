using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPostFileRepository : IAsyncRepository<PostFile, int>, IRepository<PostFile, int>
{
}