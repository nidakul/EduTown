using Application.Features.SchoolTypeClasses.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SchoolTypeClasses;

public class SchoolTypeClassManager : ISchoolTypeClassService
{
    private readonly ISchoolTypeClassRepository _schoolTypeClassRepository;
    private readonly SchoolTypeClassBusinessRules _schoolTypeClassBusinessRules;

    public SchoolTypeClassManager(ISchoolTypeClassRepository schoolTypeClassRepository, SchoolTypeClassBusinessRules schoolTypeClassBusinessRules)
    {
        _schoolTypeClassRepository = schoolTypeClassRepository;
        _schoolTypeClassBusinessRules = schoolTypeClassBusinessRules;
    }

    public async Task<SchoolTypeClass?> GetAsync(
        Expression<Func<SchoolTypeClass, bool>> predicate,
        Func<IQueryable<SchoolTypeClass>, IIncludableQueryable<SchoolTypeClass, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SchoolTypeClass? schoolTypeClass = await _schoolTypeClassRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return schoolTypeClass;
    }

    public async Task<IPaginate<SchoolTypeClass>?> GetListAsync(
        Expression<Func<SchoolTypeClass, bool>>? predicate = null,
        Func<IQueryable<SchoolTypeClass>, IOrderedQueryable<SchoolTypeClass>>? orderBy = null,
        Func<IQueryable<SchoolTypeClass>, IIncludableQueryable<SchoolTypeClass, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SchoolTypeClass> schoolTypeClassList = await _schoolTypeClassRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return schoolTypeClassList;
    }

    public async Task<SchoolTypeClass> AddAsync(SchoolTypeClass schoolTypeClass)
    {
        SchoolTypeClass addedSchoolTypeClass = await _schoolTypeClassRepository.AddAsync(schoolTypeClass);

        return addedSchoolTypeClass;
    }

    public async Task<SchoolTypeClass> UpdateAsync(SchoolTypeClass schoolTypeClass)
    {
        SchoolTypeClass updatedSchoolTypeClass = await _schoolTypeClassRepository.UpdateAsync(schoolTypeClass);

        return updatedSchoolTypeClass;
    }

    public async Task<SchoolTypeClass> DeleteAsync(SchoolTypeClass schoolTypeClass, bool permanent = false)
    {
        SchoolTypeClass deletedSchoolTypeClass = await _schoolTypeClassRepository.DeleteAsync(schoolTypeClass);

        return deletedSchoolTypeClass;
    }
}
