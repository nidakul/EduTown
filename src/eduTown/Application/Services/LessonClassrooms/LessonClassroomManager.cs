using Application.Features.LessonClassrooms.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LessonClassrooms;

public class LessonClassroomManager : ILessonClassroomService
{
    private readonly ILessonClassroomRepository _lessonClassroomRepository;
    private readonly LessonClassroomBusinessRules _lessonClassroomBusinessRules;

    public LessonClassroomManager(ILessonClassroomRepository lessonClassroomRepository, LessonClassroomBusinessRules lessonClassroomBusinessRules)
    {
        _lessonClassroomRepository = lessonClassroomRepository;
        _lessonClassroomBusinessRules = lessonClassroomBusinessRules;
    }

    public async Task<LessonClassroom?> GetAsync(
        Expression<Func<LessonClassroom, bool>> predicate,
        Func<IQueryable<LessonClassroom>, IIncludableQueryable<LessonClassroom, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        LessonClassroom? lessonClassroom = await _lessonClassroomRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return lessonClassroom;
    }

    public async Task<IPaginate<LessonClassroom>?> GetListAsync(
        Expression<Func<LessonClassroom, bool>>? predicate = null,
        Func<IQueryable<LessonClassroom>, IOrderedQueryable<LessonClassroom>>? orderBy = null,
        Func<IQueryable<LessonClassroom>, IIncludableQueryable<LessonClassroom, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<LessonClassroom> lessonClassroomList = await _lessonClassroomRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return lessonClassroomList;
    }

    public async Task<LessonClassroom> AddAsync(LessonClassroom lessonClassroom)
    {
        LessonClassroom addedLessonClassroom = await _lessonClassroomRepository.AddAsync(lessonClassroom);

        return addedLessonClassroom;
    }

    public async Task<LessonClassroom> UpdateAsync(LessonClassroom lessonClassroom)
    {
        LessonClassroom updatedLessonClassroom = await _lessonClassroomRepository.UpdateAsync(lessonClassroom);

        return updatedLessonClassroom;
    }

    public async Task<LessonClassroom> DeleteAsync(LessonClassroom lessonClassroom, bool permanent = false)
    {
        LessonClassroom deletedLessonClassroom = await _lessonClassroomRepository.DeleteAsync(lessonClassroom);

        return deletedLessonClassroom;
    }
}
