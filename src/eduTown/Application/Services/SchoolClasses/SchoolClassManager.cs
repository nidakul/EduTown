using Application.Features.SchoolClasses.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SchoolClasses;

public class SchoolClassManager : ISchoolClassService
{
    private readonly ISchoolClassRepository _schoolClassRepository;
    private readonly SchoolClassBusinessRules _schoolClassBusinessRules;

    public SchoolClassManager(ISchoolClassRepository schoolClassRepository, SchoolClassBusinessRules schoolClassBusinessRules)
    {
        _schoolClassRepository = schoolClassRepository;
        _schoolClassBusinessRules = schoolClassBusinessRules;
    }

    public async Task<SchoolClass?> GetAsync(
        Expression<Func<SchoolClass, bool>> predicate,
        Func<IQueryable<SchoolClass>, IIncludableQueryable<SchoolClass, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SchoolClass? schoolClass = await _schoolClassRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return schoolClass;
    }

    public async Task<IPaginate<SchoolClass>?> GetListAsync(
        Expression<Func<SchoolClass, bool>>? predicate = null,
        Func<IQueryable<SchoolClass>, IOrderedQueryable<SchoolClass>>? orderBy = null,
        Func<IQueryable<SchoolClass>, IIncludableQueryable<SchoolClass, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SchoolClass> schoolClassList = await _schoolClassRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return schoolClassList;
    }

    public async Task<SchoolClass> AddAsync(SchoolClass schoolClass)
    {
        SchoolClass addedSchoolClass = await _schoolClassRepository.AddAsync(schoolClass);

        return addedSchoolClass;
    }

    public async Task<SchoolClass> UpdateAsync(SchoolClass schoolClass)
    {
        SchoolClass updatedSchoolClass = await _schoolClassRepository.UpdateAsync(schoolClass);

        return updatedSchoolClass;
    }

    public async Task<SchoolClass> DeleteAsync(SchoolClass schoolClass, bool permanent = false)
    {
        SchoolClass deletedSchoolClass = await _schoolClassRepository.DeleteAsync(schoolClass);

        return deletedSchoolClass;
    }
}
