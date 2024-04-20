using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserClassrooms;

public interface IUserClassroomService
{
    Task<UserClassroom?> GetAsync(
        Expression<Func<UserClassroom, bool>> predicate,
        Func<IQueryable<UserClassroom>, IIncludableQueryable<UserClassroom, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserClassroom>?> GetListAsync(
        Expression<Func<UserClassroom, bool>>? predicate = null,
        Func<IQueryable<UserClassroom>, IOrderedQueryable<UserClassroom>>? orderBy = null,
        Func<IQueryable<UserClassroom>, IIncludableQueryable<UserClassroom, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserClassroom> AddAsync(UserClassroom userClassroom);
    Task<UserClassroom> UpdateAsync(UserClassroom userClassroom);
    Task<UserClassroom> DeleteAsync(UserClassroom userClassroom, bool permanent = false);
}
