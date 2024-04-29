using Application.Features.StudentGradeLessons.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentGradeLessons;

public class StudentGradeLessonManager : IStudentGradeLessonService
{
    private readonly IStudentGradeLessonRepository _studentGradeLessonRepository;
    private readonly StudentGradeLessonBusinessRules _studentGradeLessonBusinessRules;

    public StudentGradeLessonManager(IStudentGradeLessonRepository studentGradeLessonRepository, StudentGradeLessonBusinessRules studentGradeLessonBusinessRules)
    {
        _studentGradeLessonRepository = studentGradeLessonRepository;
        _studentGradeLessonBusinessRules = studentGradeLessonBusinessRules;
    }

    public async Task<StudentGradeLesson?> GetAsync(
        Expression<Func<StudentGradeLesson, bool>> predicate,
        Func<IQueryable<StudentGradeLesson>, IIncludableQueryable<StudentGradeLesson, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        StudentGradeLesson? studentGradeLesson = await _studentGradeLessonRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return studentGradeLesson;
    }

    public async Task<IPaginate<StudentGradeLesson>?> GetListAsync(
        Expression<Func<StudentGradeLesson, bool>>? predicate = null,
        Func<IQueryable<StudentGradeLesson>, IOrderedQueryable<StudentGradeLesson>>? orderBy = null,
        Func<IQueryable<StudentGradeLesson>, IIncludableQueryable<StudentGradeLesson, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<StudentGradeLesson> studentGradeLessonList = await _studentGradeLessonRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return studentGradeLessonList;
    }

    public async Task<StudentGradeLesson> AddAsync(StudentGradeLesson studentGradeLesson)
    {
        StudentGradeLesson addedStudentGradeLesson = await _studentGradeLessonRepository.AddAsync(studentGradeLesson);

        return addedStudentGradeLesson;
    }

    public async Task<StudentGradeLesson> UpdateAsync(StudentGradeLesson studentGradeLesson)
    {
        StudentGradeLesson updatedStudentGradeLesson = await _studentGradeLessonRepository.UpdateAsync(studentGradeLesson);

        return updatedStudentGradeLesson;
    }

    public async Task<StudentGradeLesson> DeleteAsync(StudentGradeLesson studentGradeLesson, bool permanent = false)
    {
        StudentGradeLesson deletedStudentGradeLesson = await _studentGradeLessonRepository.DeleteAsync(studentGradeLesson);

        return deletedStudentGradeLesson;
    }
}
