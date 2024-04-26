using Application.Features.UserCertificates.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.UserCertificates.Rules;

public class UserCertificateBusinessRules : BaseBusinessRules
{
    private readonly IUserCertificateRepository _userCertificateRepository;
    private readonly ILocalizationService _localizationService;

    public UserCertificateBusinessRules(IUserCertificateRepository userCertificateRepository, ILocalizationService localizationService)
    {
        _userCertificateRepository = userCertificateRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, UserCertificatesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task UserCertificateShouldExistWhenSelected(UserCertificate? userCertificate)
    {
        if (userCertificate == null)
            await throwBusinessException(UserCertificatesBusinessMessages.UserCertificateNotExists);
    }

    public async Task UserCertificateIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        UserCertificate? userCertificate = await _userCertificateRepository.GetAsync(
            predicate: uc => uc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserCertificateShouldExistWhenSelected(userCertificate);
    }
}