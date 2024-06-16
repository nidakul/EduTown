using Application.Features.ExamDates.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ExamDates;

public class ExamDateManager : IExamDateService
{
    private readonly IExamDateRepository _examDateRepository;
    private readonly ExamDateBusinessRules _examDateBusinessRules;

    public ExamDateManager(IExamDateRepository examDateRepository, ExamDateBusinessRules examDateBusinessRules)
    {
        _examDateRepository = examDateRepository;
        _examDateBusinessRules = examDateBusinessRules;
    }

    public async Task<ExamDate?> GetAsync(
        Expression<Func<ExamDate, bool>> predicate,
        Func<IQueryable<ExamDate>, IIncludableQueryable<ExamDate, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ExamDate? examDate = await _examDateRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return examDate;
    }

    public async Task<IPaginate<ExamDate>?> GetListAsync(
        Expression<Func<ExamDate, bool>>? predicate = null,
        Func<IQueryable<ExamDate>, IOrderedQueryable<ExamDate>>? orderBy = null,
        Func<IQueryable<ExamDate>, IIncludableQueryable<ExamDate, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ExamDate> examDateList = await _examDateRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return examDateList;
    }

    public async Task<ExamDate> AddAsync(ExamDate examDate)
    {
        ExamDate addedExamDate = await _examDateRepository.AddAsync(examDate);

        return addedExamDate;
    }

    public async Task<ExamDate> UpdateAsync(ExamDate examDate)
    {
        ExamDate updatedExamDate = await _examDateRepository.UpdateAsync(examDate);

        return updatedExamDate;
    }

    public async Task<ExamDate> DeleteAsync(ExamDate examDate, bool permanent = false)
    {
        ExamDate deletedExamDate = await _examDateRepository.DeleteAsync(examDate);

        return deletedExamDate;
    }
}
