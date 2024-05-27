using Application.Features.UserClassrooms.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.UserClassrooms.Rules;

public class UserClassroomBusinessRules : BaseBusinessRules
{
    private readonly IUserClassroomRepository _userClassroomRepository;
    private readonly ILocalizationService _localizationService;

    public UserClassroomBusinessRules(IUserClassroomRepository userClassroomRepository, ILocalizationService localizationService)
    {
        _userClassroomRepository = userClassroomRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, UserClassroomsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task UserClassroomShouldExistWhenSelected(UserClassroom? userClassroom)
    {
        if (userClassroom == null)
            await throwBusinessException(UserClassroomsBusinessMessages.UserClassroomNotExists);
    }

    public async Task UserClassroomIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        UserClassroom? userClassroom = await _userClassroomRepository.GetAsync(
            predicate: uc => uc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserClassroomShouldExistWhenSelected(userClassroom);
    }
}