using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserClassroomRepository : EfRepositoryBase<UserClassroom, int, BaseDbContext>, IUserClassroomRepository
{
    public UserClassroomRepository(BaseDbContext context) : base(context)
    {
    }
}