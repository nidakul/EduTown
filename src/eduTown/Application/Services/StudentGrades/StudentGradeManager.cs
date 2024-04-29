using Application.Features.StudentGrades.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentGrades;

public class StudentGradeManager : IStudentGradeService
{
    private readonly IStudentGradeRepository _studentGradeRepository;
    private readonly StudentGradeBusinessRules _studentGradeBusinessRules;

    public StudentGradeManager(IStudentGradeRepository studentGradeRepository, StudentGradeBusinessRules studentGradeBusinessRules)
    {
        _studentGradeRepository = studentGradeRepository;
        _studentGradeBusinessRules = studentGradeBusinessRules;
    }

    public async Task<StudentGrade?> GetAsync(
        Expression<Func<StudentGrade, bool>> predicate,
        Func<IQueryable<StudentGrade>, IIncludableQueryable<StudentGrade, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        StudentGrade? studentGrade = await _studentGradeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return studentGrade;
    }

    public async Task<IPaginate<StudentGrade>?> GetListAsync(
        Expression<Func<StudentGrade, bool>>? predicate = null,
        Func<IQueryable<StudentGrade>, IOrderedQueryable<StudentGrade>>? orderBy = null,
        Func<IQueryable<StudentGrade>, IIncludableQueryable<StudentGrade, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<StudentGrade> studentGradeList = await _studentGradeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return studentGradeList;
    }

    public async Task<StudentGrade> AddAsync(StudentGrade studentGrade)
    {
        StudentGrade addedStudentGrade = await _studentGradeRepository.AddAsync(studentGrade);

        return addedStudentGrade;
    }

    public async Task<StudentGrade> UpdateAsync(StudentGrade studentGrade)
    {
        StudentGrade updatedStudentGrade = await _studentGradeRepository.UpdateAsync(studentGrade);

        return updatedStudentGrade;
    }

    public async Task<StudentGrade> DeleteAsync(StudentGrade studentGrade, bool permanent = false)
    {
        StudentGrade deletedStudentGrade = await _studentGradeRepository.DeleteAsync(studentGrade);

        return deletedStudentGrade;
    }
}
