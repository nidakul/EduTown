using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SchoolClassrooms;

public interface ISchoolClassroomService
{
    Task<SchoolClassroom?> GetAsync(
        Expression<Func<SchoolClassroom, bool>> predicate,
        Func<IQueryable<SchoolClassroom>, IIncludableQueryable<SchoolClassroom, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SchoolClassroom>?> GetListAsync(
        Expression<Func<SchoolClassroom, bool>>? predicate = null,
        Func<IQueryable<SchoolClassroom>, IOrderedQueryable<SchoolClassroom>>? orderBy = null,
        Func<IQueryable<SchoolClassroom>, IIncludableQueryable<SchoolClassroom, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SchoolClassroom> AddAsync(SchoolClassroom schoolClassroom);
    Task<SchoolClassroom> UpdateAsync(SchoolClassroom schoolClassroom);
    Task<SchoolClassroom> DeleteAsync(SchoolClassroom schoolClassroom, bool permanent = false);
}
