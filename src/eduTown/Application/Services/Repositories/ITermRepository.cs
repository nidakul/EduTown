using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITermRepository : IAsyncRepository<Term, int>, IRepository<Term, int>
{
}