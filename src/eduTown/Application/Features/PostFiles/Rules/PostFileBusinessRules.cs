using Application.Features.PostFiles.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.PostFiles.Rules;

public class PostFileBusinessRules : BaseBusinessRules
{
    private readonly IPostFileRepository _postFileRepository;
    private readonly ILocalizationService _localizationService;

    public PostFileBusinessRules(IPostFileRepository postFileRepository, ILocalizationService localizationService)
    {
        _postFileRepository = postFileRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PostFilesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PostFileShouldExistWhenSelected(PostFile? postFile)
    {
        if (postFile == null)
            await throwBusinessException(PostFilesBusinessMessages.PostFileNotExists);
    }

    public async Task PostFileIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        PostFile? postFile = await _postFileRepository.GetAsync(
            predicate: pf => pf.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PostFileShouldExistWhenSelected(postFile);
    }
}