using Application.Features.UserLessons.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.UserLessons.Rules;

public class UserLessonBusinessRules : BaseBusinessRules
{
    private readonly IUserLessonRepository _userLessonRepository;
    private readonly ILocalizationService _localizationService;

    public UserLessonBusinessRules(IUserLessonRepository userLessonRepository, ILocalizationService localizationService)
    {
        _userLessonRepository = userLessonRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, UserLessonsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task UserLessonShouldExistWhenSelected(UserLesson? userLesson)
    {
        if (userLesson == null)
            await throwBusinessException(UserLessonsBusinessMessages.UserLessonNotExists);
    }

    public async Task UserLessonIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        UserLesson? userLesson = await _userLessonRepository.GetAsync(
            predicate: ul => ul.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserLessonShouldExistWhenSelected(userLesson);
    }
}