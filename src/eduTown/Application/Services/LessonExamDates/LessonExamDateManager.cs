using Application.Features.LessonExamDates.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LessonExamDates;

public class LessonExamDateManager : ILessonExamDateService
{
    private readonly ILessonExamDateRepository _lessonExamDateRepository;
    private readonly LessonExamDateBusinessRules _lessonExamDateBusinessRules;

    public LessonExamDateManager(ILessonExamDateRepository lessonExamDateRepository, LessonExamDateBusinessRules lessonExamDateBusinessRules)
    {
        _lessonExamDateRepository = lessonExamDateRepository;
        _lessonExamDateBusinessRules = lessonExamDateBusinessRules;
    }

    public async Task<LessonExamDate?> GetAsync(
        Expression<Func<LessonExamDate, bool>> predicate,
        Func<IQueryable<LessonExamDate>, IIncludableQueryable<LessonExamDate, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        LessonExamDate? lessonExamDate = await _lessonExamDateRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return lessonExamDate;
    }

    public async Task<IPaginate<LessonExamDate>?> GetListAsync(
        Expression<Func<LessonExamDate, bool>>? predicate = null,
        Func<IQueryable<LessonExamDate>, IOrderedQueryable<LessonExamDate>>? orderBy = null,
        Func<IQueryable<LessonExamDate>, IIncludableQueryable<LessonExamDate, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<LessonExamDate> lessonExamDateList = await _lessonExamDateRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return lessonExamDateList;
    }

    public async Task<LessonExamDate> AddAsync(LessonExamDate lessonExamDate)
    {
        LessonExamDate addedLessonExamDate = await _lessonExamDateRepository.AddAsync(lessonExamDate);

        return addedLessonExamDate;
    }

    public async Task<LessonExamDate> UpdateAsync(LessonExamDate lessonExamDate)
    {
        LessonExamDate updatedLessonExamDate = await _lessonExamDateRepository.UpdateAsync(lessonExamDate);

        return updatedLessonExamDate;
    }

    public async Task<LessonExamDate> DeleteAsync(LessonExamDate lessonExamDate, bool permanent = false)
    {
        LessonExamDate deletedLessonExamDate = await _lessonExamDateRepository.DeleteAsync(lessonExamDate);

        return deletedLessonExamDate;
    }
}
