using Application.Features.PostFiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PostFiles.Commands.Update;

public class UpdatePostFileCommand : IRequest<UpdatedPostFileResponse>
{
    public int Id { get; set; }
    public required int PostId { get; set; }
    public required string FilePath { get; set; }

    public class UpdatePostFileCommandHandler : IRequestHandler<UpdatePostFileCommand, UpdatedPostFileResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostFileRepository _postFileRepository;
        private readonly PostFileBusinessRules _postFileBusinessRules;

        public UpdatePostFileCommandHandler(IMapper mapper, IPostFileRepository postFileRepository,
                                         PostFileBusinessRules postFileBusinessRules)
        {
            _mapper = mapper;
            _postFileRepository = postFileRepository;
            _postFileBusinessRules = postFileBusinessRules;
        }

        public async Task<UpdatedPostFileResponse> Handle(UpdatePostFileCommand request, CancellationToken cancellationToken)
        {
            PostFile? postFile = await _postFileRepository.GetAsync(predicate: pf => pf.Id == request.Id, cancellationToken: cancellationToken);
            await _postFileBusinessRules.PostFileShouldExistWhenSelected(postFile);
            postFile = _mapper.Map(request, postFile);

            await _postFileRepository.UpdateAsync(postFile!);

            UpdatedPostFileResponse response = _mapper.Map<UpdatedPostFileResponse>(postFile);
            return response;
        }
    }
}