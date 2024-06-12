using Application.Features.SchoolTypes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SchoolTypes;

public class SchoolTypeManager : ISchoolTypeService
{
    private readonly ISchoolTypeRepository _schoolTypeRepository;
    private readonly SchoolTypeBusinessRules _schoolTypeBusinessRules;

    public SchoolTypeManager(ISchoolTypeRepository schoolTypeRepository, SchoolTypeBusinessRules schoolTypeBusinessRules)
    {
        _schoolTypeRepository = schoolTypeRepository;
        _schoolTypeBusinessRules = schoolTypeBusinessRules;
    }

    public async Task<SchoolType?> GetAsync(
        Expression<Func<SchoolType, bool>> predicate,
        Func<IQueryable<SchoolType>, IIncludableQueryable<SchoolType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SchoolType? schoolType = await _schoolTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return schoolType;
    }

    public async Task<IPaginate<SchoolType>?> GetListAsync(
        Expression<Func<SchoolType, bool>>? predicate = null,
        Func<IQueryable<SchoolType>, IOrderedQueryable<SchoolType>>? orderBy = null,
        Func<IQueryable<SchoolType>, IIncludableQueryable<SchoolType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SchoolType> schoolTypeList = await _schoolTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return schoolTypeList;
    }

    public async Task<SchoolType> AddAsync(SchoolType schoolType)
    {
        SchoolType addedSchoolType = await _schoolTypeRepository.AddAsync(schoolType);

        return addedSchoolType;
    }

    public async Task<SchoolType> UpdateAsync(SchoolType schoolType)
    {
        SchoolType updatedSchoolType = await _schoolTypeRepository.UpdateAsync(schoolType);

        return updatedSchoolType;
    }

    public async Task<SchoolType> DeleteAsync(SchoolType schoolType, bool permanent = false)
    {
        SchoolType deletedSchoolType = await _schoolTypeRepository.DeleteAsync(schoolType);

        return deletedSchoolType;
    }
}
