using Application.Features.SchoolClassrooms.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SchoolClassrooms;

public class SchoolClassroomManager : ISchoolClassroomService
{
    private readonly ISchoolClassroomRepository _schoolClassroomRepository;
    private readonly SchoolClassroomBusinessRules _schoolClassroomBusinessRules;

    public SchoolClassroomManager(ISchoolClassroomRepository schoolClassroomRepository, SchoolClassroomBusinessRules schoolClassroomBusinessRules)
    {
        _schoolClassroomRepository = schoolClassroomRepository;
        _schoolClassroomBusinessRules = schoolClassroomBusinessRules;
    }

    public async Task<SchoolClassroom?> GetAsync(
        Expression<Func<SchoolClassroom, bool>> predicate,
        Func<IQueryable<SchoolClassroom>, IIncludableQueryable<SchoolClassroom, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SchoolClassroom? schoolClassroom = await _schoolClassroomRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return schoolClassroom;
    }

    public async Task<IPaginate<SchoolClassroom>?> GetListAsync(
        Expression<Func<SchoolClassroom, bool>>? predicate = null,
        Func<IQueryable<SchoolClassroom>, IOrderedQueryable<SchoolClassroom>>? orderBy = null,
        Func<IQueryable<SchoolClassroom>, IIncludableQueryable<SchoolClassroom, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SchoolClassroom> schoolClassroomList = await _schoolClassroomRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return schoolClassroomList;
    }

    public async Task<SchoolClassroom> AddAsync(SchoolClassroom schoolClassroom)
    {
        SchoolClassroom addedSchoolClassroom = await _schoolClassroomRepository.AddAsync(schoolClassroom);

        return addedSchoolClassroom;
    }

    public async Task<SchoolClassroom> UpdateAsync(SchoolClassroom schoolClassroom)
    {
        SchoolClassroom updatedSchoolClassroom = await _schoolClassroomRepository.UpdateAsync(schoolClassroom);

        return updatedSchoolClassroom;
    }

    public async Task<SchoolClassroom> DeleteAsync(SchoolClassroom schoolClassroom, bool permanent = false)
    {
        SchoolClassroom deletedSchoolClassroom = await _schoolClassroomRepository.DeleteAsync(schoolClassroom);

        return deletedSchoolClassroom;
    }
}
