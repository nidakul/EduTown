using Application.Features.SchoolClassLessons.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SchoolClassLessons;

public class SchoolClassLessonManager : ISchoolClassLessonService
{
    private readonly ISchoolClassLessonRepository _schoolClassLessonRepository;
    private readonly SchoolClassLessonBusinessRules _schoolClassLessonBusinessRules;

    public SchoolClassLessonManager(ISchoolClassLessonRepository schoolClassLessonRepository, SchoolClassLessonBusinessRules schoolClassLessonBusinessRules)
    {
        _schoolClassLessonRepository = schoolClassLessonRepository;
        _schoolClassLessonBusinessRules = schoolClassLessonBusinessRules;
    }

    public async Task<SchoolClassLesson?> GetAsync(
        Expression<Func<SchoolClassLesson, bool>> predicate,
        Func<IQueryable<SchoolClassLesson>, IIncludableQueryable<SchoolClassLesson, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SchoolClassLesson? schoolClassLesson = await _schoolClassLessonRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return schoolClassLesson;
    }

    public async Task<IPaginate<SchoolClassLesson>?> GetListAsync(
        Expression<Func<SchoolClassLesson, bool>>? predicate = null,
        Func<IQueryable<SchoolClassLesson>, IOrderedQueryable<SchoolClassLesson>>? orderBy = null,
        Func<IQueryable<SchoolClassLesson>, IIncludableQueryable<SchoolClassLesson, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SchoolClassLesson> schoolClassLessonList = await _schoolClassLessonRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return schoolClassLessonList;
    }

    public async Task<SchoolClassLesson> AddAsync(SchoolClassLesson schoolClassLesson)
    {
        SchoolClassLesson addedSchoolClassLesson = await _schoolClassLessonRepository.AddAsync(schoolClassLesson);

        return addedSchoolClassLesson;
    }

    public async Task<SchoolClassLesson> UpdateAsync(SchoolClassLesson schoolClassLesson)
    {
        SchoolClassLesson updatedSchoolClassLesson = await _schoolClassLessonRepository.UpdateAsync(schoolClassLesson);

        return updatedSchoolClassLesson;
    }

    public async Task<SchoolClassLesson> DeleteAsync(SchoolClassLesson schoolClassLesson, bool permanent = false)
    {
        SchoolClassLesson deletedSchoolClassLesson = await _schoolClassLessonRepository.DeleteAsync(schoolClassLesson);

        return deletedSchoolClassLesson;
    }
}
