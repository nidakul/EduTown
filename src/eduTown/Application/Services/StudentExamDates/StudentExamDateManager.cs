using Application.Features.StudentExamDates.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentExamDates;

public class StudentExamDateManager : IStudentExamDateService
{
    private readonly IStudentExamDateRepository _studentExamDateRepository;
    private readonly StudentExamDateBusinessRules _studentExamDateBusinessRules;

    public StudentExamDateManager(IStudentExamDateRepository studentExamDateRepository, StudentExamDateBusinessRules studentExamDateBusinessRules)
    {
        _studentExamDateRepository = studentExamDateRepository;
        _studentExamDateBusinessRules = studentExamDateBusinessRules;
    }

    public async Task<StudentExamDate?> GetAsync(
        Expression<Func<StudentExamDate, bool>> predicate,
        Func<IQueryable<StudentExamDate>, IIncludableQueryable<StudentExamDate, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        StudentExamDate? studentExamDate = await _studentExamDateRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return studentExamDate;
    }

    public async Task<IPaginate<StudentExamDate>?> GetListAsync(
        Expression<Func<StudentExamDate, bool>>? predicate = null,
        Func<IQueryable<StudentExamDate>, IOrderedQueryable<StudentExamDate>>? orderBy = null,
        Func<IQueryable<StudentExamDate>, IIncludableQueryable<StudentExamDate, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<StudentExamDate> studentExamDateList = await _studentExamDateRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return studentExamDateList;
    }

    public async Task<StudentExamDate> AddAsync(StudentExamDate studentExamDate)
    {
        StudentExamDate addedStudentExamDate = await _studentExamDateRepository.AddAsync(studentExamDate);

        return addedStudentExamDate;
    }

    public async Task<StudentExamDate> UpdateAsync(StudentExamDate studentExamDate)
    {
        StudentExamDate updatedStudentExamDate = await _studentExamDateRepository.UpdateAsync(studentExamDate);

        return updatedStudentExamDate;
    }

    public async Task<StudentExamDate> DeleteAsync(StudentExamDate studentExamDate, bool permanent = false)
    {
        StudentExamDate deletedStudentExamDate = await _studentExamDateRepository.DeleteAsync(studentExamDate);

        return deletedStudentExamDate;
    }
}
