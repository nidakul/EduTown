using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TermRepository : EfRepositoryBase<Term, int, BaseDbContext>, ITermRepository
{
    public TermRepository(BaseDbContext context) : base(context)
    {
    }
}