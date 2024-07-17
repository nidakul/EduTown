using Application.Features.SchoolClassBranches.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SchoolClassBranches;

public class SchoolClassBranchManager : ISchoolClassBranchService
{
    private readonly ISchoolClassBranchRepository _schoolClassBranchRepository;
    private readonly SchoolClassBranchBusinessRules _schoolClassBranchBusinessRules;

    public SchoolClassBranchManager(ISchoolClassBranchRepository schoolClassBranchRepository, SchoolClassBranchBusinessRules schoolClassBranchBusinessRules)
    {
        _schoolClassBranchRepository = schoolClassBranchRepository;
        _schoolClassBranchBusinessRules = schoolClassBranchBusinessRules;
    }

    public async Task<SchoolClassBranch?> GetAsync(
        Expression<Func<SchoolClassBranch, bool>> predicate,
        Func<IQueryable<SchoolClassBranch>, IIncludableQueryable<SchoolClassBranch, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SchoolClassBranch? schoolClassBranch = await _schoolClassBranchRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return schoolClassBranch;
    }

    public async Task<IPaginate<SchoolClassBranch>?> GetListAsync(
        Expression<Func<SchoolClassBranch, bool>>? predicate = null,
        Func<IQueryable<SchoolClassBranch>, IOrderedQueryable<SchoolClassBranch>>? orderBy = null,
        Func<IQueryable<SchoolClassBranch>, IIncludableQueryable<SchoolClassBranch, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SchoolClassBranch> schoolClassBranchList = await _schoolClassBranchRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return schoolClassBranchList;
    }

    public async Task<SchoolClassBranch> AddAsync(SchoolClassBranch schoolClassBranch)
    {
        SchoolClassBranch addedSchoolClassBranch = await _schoolClassBranchRepository.AddAsync(schoolClassBranch);

        return addedSchoolClassBranch;
    }

    public async Task<SchoolClassBranch> UpdateAsync(SchoolClassBranch schoolClassBranch)
    {
        SchoolClassBranch updatedSchoolClassBranch = await _schoolClassBranchRepository.UpdateAsync(schoolClassBranch);

        return updatedSchoolClassBranch;
    }

    public async Task<SchoolClassBranch> DeleteAsync(SchoolClassBranch schoolClassBranch, bool permanent = false)
    {
        SchoolClassBranch deletedSchoolClassBranch = await _schoolClassBranchRepository.DeleteAsync(schoolClassBranch);

        return deletedSchoolClassBranch;
    }
}
