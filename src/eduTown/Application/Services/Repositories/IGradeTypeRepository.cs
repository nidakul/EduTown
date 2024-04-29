using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IGradeTypeRepository : IAsyncRepository<GradeType, int>, IRepository<GradeType, int>
{
}