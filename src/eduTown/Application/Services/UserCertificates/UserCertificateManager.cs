using Application.Features.UserCertificates.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserCertificates;

public class UserCertificateManager : IUserCertificateService
{
    private readonly IUserCertificateRepository _userCertificateRepository;
    private readonly UserCertificateBusinessRules _userCertificateBusinessRules;

    public UserCertificateManager(IUserCertificateRepository userCertificateRepository, UserCertificateBusinessRules userCertificateBusinessRules)
    {
        _userCertificateRepository = userCertificateRepository;
        _userCertificateBusinessRules = userCertificateBusinessRules;
    }

    public async Task<UserCertificate?> GetAsync(
        Expression<Func<UserCertificate, bool>> predicate,
        Func<IQueryable<UserCertificate>, IIncludableQueryable<UserCertificate, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserCertificate? userCertificate = await _userCertificateRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return userCertificate;
    }

    public async Task<IPaginate<UserCertificate>?> GetListAsync(
        Expression<Func<UserCertificate, bool>>? predicate = null,
        Func<IQueryable<UserCertificate>, IOrderedQueryable<UserCertificate>>? orderBy = null,
        Func<IQueryable<UserCertificate>, IIncludableQueryable<UserCertificate, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserCertificate> userCertificateList = await _userCertificateRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userCertificateList;
    }

    public async Task<UserCertificate> AddAsync(UserCertificate userCertificate)
    {
        UserCertificate addedUserCertificate = await _userCertificateRepository.AddAsync(userCertificate);

        return addedUserCertificate;
    }

    public async Task<UserCertificate> UpdateAsync(UserCertificate userCertificate)
    {
        UserCertificate updatedUserCertificate = await _userCertificateRepository.UpdateAsync(userCertificate);

        return updatedUserCertificate;
    }

    public async Task<UserCertificate> DeleteAsync(UserCertificate userCertificate, bool permanent = false)
    {
        UserCertificate deletedUserCertificate = await _userCertificateRepository.DeleteAsync(userCertificate);

        return deletedUserCertificate;
    }
}
