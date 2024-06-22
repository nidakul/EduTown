using Application.Features.SchoolLessonClasses.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SchoolLessonClasses;

public class SchoolLessonClassManager : ISchoolLessonClassService
{
    private readonly ISchoolLessonClassRepository _schoolLessonClassRepository;
    private readonly SchoolLessonClassBusinessRules _schoolLessonClassBusinessRules;

    public SchoolLessonClassManager(ISchoolLessonClassRepository schoolLessonClassRepository, SchoolLessonClassBusinessRules schoolLessonClassBusinessRules)
    {
        _schoolLessonClassRepository = schoolLessonClassRepository;
        _schoolLessonClassBusinessRules = schoolLessonClassBusinessRules;
    }

    public async Task<SchoolLessonClass?> GetAsync(
        Expression<Func<SchoolLessonClass, bool>> predicate,
        Func<IQueryable<SchoolLessonClass>, IIncludableQueryable<SchoolLessonClass, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SchoolLessonClass? schoolLessonClass = await _schoolLessonClassRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return schoolLessonClass;
    }

    public async Task<IPaginate<SchoolLessonClass>?> GetListAsync(
        Expression<Func<SchoolLessonClass, bool>>? predicate = null,
        Func<IQueryable<SchoolLessonClass>, IOrderedQueryable<SchoolLessonClass>>? orderBy = null,
        Func<IQueryable<SchoolLessonClass>, IIncludableQueryable<SchoolLessonClass, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SchoolLessonClass> schoolLessonClassList = await _schoolLessonClassRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return schoolLessonClassList;
    }

    public async Task<SchoolLessonClass> AddAsync(SchoolLessonClass schoolLessonClass)
    {
        SchoolLessonClass addedSchoolLessonClass = await _schoolLessonClassRepository.AddAsync(schoolLessonClass);

        return addedSchoolLessonClass;
    }

    public async Task<SchoolLessonClass> UpdateAsync(SchoolLessonClass schoolLessonClass)
    {
        SchoolLessonClass updatedSchoolLessonClass = await _schoolLessonClassRepository.UpdateAsync(schoolLessonClass);

        return updatedSchoolLessonClass;
    }

    public async Task<SchoolLessonClass> DeleteAsync(SchoolLessonClass schoolLessonClass, bool permanent = false)
    {
        SchoolLessonClass deletedSchoolLessonClass = await _schoolLessonClassRepository.DeleteAsync(schoolLessonClass);

        return deletedSchoolLessonClass;
    }
}
