using Application.Features.InstructorDepartments.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.InstructorDepartments;

public class InstructorDepartmentManager : IInstructorDepartmentService
{
    private readonly IInstructorDepartmentRepository _instructorDepartmentRepository;
    private readonly InstructorDepartmentBusinessRules _instructorDepartmentBusinessRules;

    public InstructorDepartmentManager(IInstructorDepartmentRepository instructorDepartmentRepository, InstructorDepartmentBusinessRules instructorDepartmentBusinessRules)
    {
        _instructorDepartmentRepository = instructorDepartmentRepository;
        _instructorDepartmentBusinessRules = instructorDepartmentBusinessRules;
    }

    public async Task<InstructorDepartment?> GetAsync(
        Expression<Func<InstructorDepartment, bool>> predicate,
        Func<IQueryable<InstructorDepartment>, IIncludableQueryable<InstructorDepartment, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        InstructorDepartment? instructorDepartment = await _instructorDepartmentRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return instructorDepartment;
    }

    public async Task<IPaginate<InstructorDepartment>?> GetListAsync(
        Expression<Func<InstructorDepartment, bool>>? predicate = null,
        Func<IQueryable<InstructorDepartment>, IOrderedQueryable<InstructorDepartment>>? orderBy = null,
        Func<IQueryable<InstructorDepartment>, IIncludableQueryable<InstructorDepartment, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<InstructorDepartment> instructorDepartmentList = await _instructorDepartmentRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return instructorDepartmentList;
    }

    public async Task<InstructorDepartment> AddAsync(InstructorDepartment instructorDepartment)
    {
        InstructorDepartment addedInstructorDepartment = await _instructorDepartmentRepository.AddAsync(instructorDepartment);

        return addedInstructorDepartment;
    }

    public async Task<InstructorDepartment> UpdateAsync(InstructorDepartment instructorDepartment)
    {
        InstructorDepartment updatedInstructorDepartment = await _instructorDepartmentRepository.UpdateAsync(instructorDepartment);

        return updatedInstructorDepartment;
    }

    public async Task<InstructorDepartment> DeleteAsync(InstructorDepartment instructorDepartment, bool permanent = false)
    {
        InstructorDepartment deletedInstructorDepartment = await _instructorDepartmentRepository.DeleteAsync(instructorDepartment);

        return deletedInstructorDepartment;
    }
}
