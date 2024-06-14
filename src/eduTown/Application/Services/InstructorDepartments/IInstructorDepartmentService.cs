using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.InstructorDepartments;

public interface IInstructorDepartmentService
{
    Task<InstructorDepartment?> GetAsync(
        Expression<Func<InstructorDepartment, bool>> predicate,
        Func<IQueryable<InstructorDepartment>, IIncludableQueryable<InstructorDepartment, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<InstructorDepartment>?> GetListAsync(
        Expression<Func<InstructorDepartment, bool>>? predicate = null,
        Func<IQueryable<InstructorDepartment>, IOrderedQueryable<InstructorDepartment>>? orderBy = null,
        Func<IQueryable<InstructorDepartment>, IIncludableQueryable<InstructorDepartment, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<InstructorDepartment> AddAsync(InstructorDepartment instructorDepartment);
    Task<InstructorDepartment> UpdateAsync(InstructorDepartment instructorDepartment);
    Task<InstructorDepartment> DeleteAsync(InstructorDepartment instructorDepartment, bool permanent = false);
}
