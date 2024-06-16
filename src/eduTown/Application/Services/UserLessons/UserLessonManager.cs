using Application.Features.UserLessons.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserLessons;

public class UserLessonManager : IUserLessonService
{
    private readonly IUserLessonRepository _userLessonRepository;
    private readonly UserLessonBusinessRules _userLessonBusinessRules;

    public UserLessonManager(IUserLessonRepository userLessonRepository, UserLessonBusinessRules userLessonBusinessRules)
    {
        _userLessonRepository = userLessonRepository;
        _userLessonBusinessRules = userLessonBusinessRules;
    }

    public async Task<UserLesson?> GetAsync(
        Expression<Func<UserLesson, bool>> predicate,
        Func<IQueryable<UserLesson>, IIncludableQueryable<UserLesson, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserLesson? userLesson = await _userLessonRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return userLesson;
    }

    public async Task<IPaginate<UserLesson>?> GetListAsync(
        Expression<Func<UserLesson, bool>>? predicate = null,
        Func<IQueryable<UserLesson>, IOrderedQueryable<UserLesson>>? orderBy = null,
        Func<IQueryable<UserLesson>, IIncludableQueryable<UserLesson, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserLesson> userLessonList = await _userLessonRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userLessonList;
    }

    public async Task<UserLesson> AddAsync(UserLesson userLesson)
    {
        UserLesson addedUserLesson = await _userLessonRepository.AddAsync(userLesson);

        return addedUserLesson;
    }

    public async Task<UserLesson> UpdateAsync(UserLesson userLesson)
    {
        UserLesson updatedUserLesson = await _userLessonRepository.UpdateAsync(userLesson);

        return updatedUserLesson;
    }

    public async Task<UserLesson> DeleteAsync(UserLesson userLesson, bool permanent = false)
    {
        UserLesson deletedUserLesson = await _userLessonRepository.DeleteAsync(userLesson);

        return deletedUserLesson;
    }
}
