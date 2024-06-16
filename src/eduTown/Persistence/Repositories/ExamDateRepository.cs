using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ExamDateRepository : EfRepositoryBase<ExamDate, int, BaseDbContext>, IExamDateRepository
{
    public ExamDateRepository(BaseDbContext context) : base(context)
    {
    }
}