using Application.Features.GradeTypes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.GradeTypes;

public class GradeTypeManager : IGradeTypeService
{
    private readonly IGradeTypeRepository _gradeTypeRepository;
    private readonly GradeTypeBusinessRules _gradeTypeBusinessRules;

    public GradeTypeManager(IGradeTypeRepository gradeTypeRepository, GradeTypeBusinessRules gradeTypeBusinessRules)
    {
        _gradeTypeRepository = gradeTypeRepository;
        _gradeTypeBusinessRules = gradeTypeBusinessRules;
    }

    public async Task<GradeType?> GetAsync(
        Expression<Func<GradeType, bool>> predicate,
        Func<IQueryable<GradeType>, IIncludableQueryable<GradeType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        GradeType? gradeType = await _gradeTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return gradeType;
    }

    public async Task<IPaginate<GradeType>?> GetListAsync(
        Expression<Func<GradeType, bool>>? predicate = null,
        Func<IQueryable<GradeType>, IOrderedQueryable<GradeType>>? orderBy = null,
        Func<IQueryable<GradeType>, IIncludableQueryable<GradeType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<GradeType> gradeTypeList = await _gradeTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return gradeTypeList;
    }

    public async Task<GradeType> AddAsync(GradeType gradeType)
    {
        GradeType addedGradeType = await _gradeTypeRepository.AddAsync(gradeType);

        return addedGradeType;
    }

    public async Task<GradeType> UpdateAsync(GradeType gradeType)
    {
        GradeType updatedGradeType = await _gradeTypeRepository.UpdateAsync(gradeType);

        return updatedGradeType;
    }

    public async Task<GradeType> DeleteAsync(GradeType gradeType, bool permanent = false)
    {
        GradeType deletedGradeType = await _gradeTypeRepository.DeleteAsync(gradeType);

        return deletedGradeType;
    }
}
