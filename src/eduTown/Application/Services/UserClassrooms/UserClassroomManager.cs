using Application.Features.UserClassrooms.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserClassrooms;

public class UserClassroomManager : IUserClassroomService
{
    private readonly IUserClassroomRepository _userClassroomRepository;
    private readonly UserClassroomBusinessRules _userClassroomBusinessRules;

    public UserClassroomManager(IUserClassroomRepository userClassroomRepository, UserClassroomBusinessRules userClassroomBusinessRules)
    {
        _userClassroomRepository = userClassroomRepository;
        _userClassroomBusinessRules = userClassroomBusinessRules;
    }

    public async Task<UserClassroom?> GetAsync(
        Expression<Func<UserClassroom, bool>> predicate,
        Func<IQueryable<UserClassroom>, IIncludableQueryable<UserClassroom, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserClassroom? userClassroom = await _userClassroomRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return userClassroom;
    }

    public async Task<IPaginate<UserClassroom>?> GetListAsync(
        Expression<Func<UserClassroom, bool>>? predicate = null,
        Func<IQueryable<UserClassroom>, IOrderedQueryable<UserClassroom>>? orderBy = null,
        Func<IQueryable<UserClassroom>, IIncludableQueryable<UserClassroom, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserClassroom> userClassroomList = await _userClassroomRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userClassroomList;
    }

    public async Task<UserClassroom> AddAsync(UserClassroom userClassroom)
    {
        UserClassroom addedUserClassroom = await _userClassroomRepository.AddAsync(userClassroom);

        return addedUserClassroom;
    }

    public async Task<UserClassroom> UpdateAsync(UserClassroom userClassroom)
    {
        UserClassroom updatedUserClassroom = await _userClassroomRepository.UpdateAsync(userClassroom);

        return updatedUserClassroom;
    }

    public async Task<UserClassroom> DeleteAsync(UserClassroom userClassroom, bool permanent = false)
    {
        UserClassroom deletedUserClassroom = await _userClassroomRepository.DeleteAsync(userClassroom);

        return deletedUserClassroom;
    }
}
