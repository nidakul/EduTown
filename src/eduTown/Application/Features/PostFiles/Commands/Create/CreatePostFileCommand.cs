using Application.Features.PostFiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PostFiles.Commands.Create;

public class CreatePostFileCommand : IRequest<CreatedPostFileResponse>
{
    public required int PostId { get; set; }
    public required string FilePath { get; set; }

    public class CreatePostFileCommandHandler : IRequestHandler<CreatePostFileCommand, CreatedPostFileResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostFileRepository _postFileRepository;
        private readonly PostFileBusinessRules _postFileBusinessRules;

        public CreatePostFileCommandHandler(IMapper mapper, IPostFileRepository postFileRepository,
                                         PostFileBusinessRules postFileBusinessRules)
        {
            _mapper = mapper;
            _postFileRepository = postFileRepository;
            _postFileBusinessRules = postFileBusinessRules;
        }

        public async Task<CreatedPostFileResponse> Handle(CreatePostFileCommand request, CancellationToken cancellationToken)
        {
            PostFile postFile = _mapper.Map<PostFile>(request);

            await _postFileRepository.AddAsync(postFile);

            CreatedPostFileResponse response = _mapper.Map<CreatedPostFileResponse>(postFile);
            return response;
        }
    }
}