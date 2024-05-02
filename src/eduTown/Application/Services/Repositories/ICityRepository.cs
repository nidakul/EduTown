using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICityRepository : IAsyncRepository<City, int>, IRepository<City, int>
{
}