using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class GradeTypeRepository : EfRepositoryBase<GradeType, int, BaseDbContext>, IGradeTypeRepository
{
    public GradeTypeRepository(BaseDbContext context) : base(context)
    {
    }
}