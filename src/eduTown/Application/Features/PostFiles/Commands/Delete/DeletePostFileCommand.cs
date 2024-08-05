using Application.Features.PostFiles.Constants;
using Application.Features.PostFiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PostFiles.Commands.Delete;

public class DeletePostFileCommand : IRequest<DeletedPostFileResponse>
{
    public int Id { get; set; }

    public class DeletePostFileCommandHandler : IRequestHandler<DeletePostFileCommand, DeletedPostFileResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostFileRepository _postFileRepository;
        private readonly PostFileBusinessRules _postFileBusinessRules;

        public DeletePostFileCommandHandler(IMapper mapper, IPostFileRepository postFileRepository,
                                         PostFileBusinessRules postFileBusinessRules)
        {
            _mapper = mapper;
            _postFileRepository = postFileRepository;
            _postFileBusinessRules = postFileBusinessRules;
        }

        public async Task<DeletedPostFileResponse> Handle(DeletePostFileCommand request, CancellationToken cancellationToken)
        {
            PostFile? postFile = await _postFileRepository.GetAsync(predicate: pf => pf.Id == request.Id, cancellationToken: cancellationToken);
            await _postFileBusinessRules.PostFileShouldExistWhenSelected(postFile);

            await _postFileRepository.DeleteAsync(postFile!);

            DeletedPostFileResponse response = _mapper.Map<DeletedPostFileResponse>(postFile);
            return response;
        }
    }
}