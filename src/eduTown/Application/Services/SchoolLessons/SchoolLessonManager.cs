using Application.Features.SchoolLessons.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SchoolLessons;

public class SchoolLessonManager : ISchoolLessonService
{
    private readonly ISchoolLessonRepository _schoolLessonRepository;
    private readonly SchoolLessonBusinessRules _schoolLessonBusinessRules;

    public SchoolLessonManager(ISchoolLessonRepository schoolLessonRepository, SchoolLessonBusinessRules schoolLessonBusinessRules)
    {
        _schoolLessonRepository = schoolLessonRepository;
        _schoolLessonBusinessRules = schoolLessonBusinessRules;
    }

    public async Task<SchoolLesson?> GetAsync(
        Expression<Func<SchoolLesson, bool>> predicate,
        Func<IQueryable<SchoolLesson>, IIncludableQueryable<SchoolLesson, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SchoolLesson? schoolLesson = await _schoolLessonRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return schoolLesson;
    }

    public async Task<IPaginate<SchoolLesson>?> GetListAsync(
        Expression<Func<SchoolLesson, bool>>? predicate = null,
        Func<IQueryable<SchoolLesson>, IOrderedQueryable<SchoolLesson>>? orderBy = null,
        Func<IQueryable<SchoolLesson>, IIncludableQueryable<SchoolLesson, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SchoolLesson> schoolLessonList = await _schoolLessonRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return schoolLessonList;
    }

    public async Task<SchoolLesson> AddAsync(SchoolLesson schoolLesson)
    {
        SchoolLesson addedSchoolLesson = await _schoolLessonRepository.AddAsync(schoolLesson);

        return addedSchoolLesson;
    }

    public async Task<SchoolLesson> UpdateAsync(SchoolLesson schoolLesson)
    {
        SchoolLesson updatedSchoolLesson = await _schoolLessonRepository.UpdateAsync(schoolLesson);

        return updatedSchoolLesson;
    }

    public async Task<SchoolLesson> DeleteAsync(SchoolLesson schoolLesson, bool permanent = false)
    {
        SchoolLesson deletedSchoolLesson = await _schoolLessonRepository.DeleteAsync(schoolLesson);

        return deletedSchoolLesson;
    }
}
