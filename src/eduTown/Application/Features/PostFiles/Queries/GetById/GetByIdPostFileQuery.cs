using Application.Features.PostFiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PostFiles.Queries.GetById;

public class GetByIdPostFileQuery : IRequest<GetByIdPostFileResponse>
{
    public int Id { get; set; }

    public class GetByIdPostFileQueryHandler : IRequestHandler<GetByIdPostFileQuery, GetByIdPostFileResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostFileRepository _postFileRepository;
        private readonly PostFileBusinessRules _postFileBusinessRules;

        public GetByIdPostFileQueryHandler(IMapper mapper, IPostFileRepository postFileRepository, PostFileBusinessRules postFileBusinessRules)
        {
            _mapper = mapper;
            _postFileRepository = postFileRepository;
            _postFileBusinessRules = postFileBusinessRules;
        }

        public async Task<GetByIdPostFileResponse> Handle(GetByIdPostFileQuery request, CancellationToken cancellationToken)
        {
            PostFile? postFile = await _postFileRepository.GetAsync(predicate: pf => pf.Id == request.Id, cancellationToken: cancellationToken);
            await _postFileBusinessRules.PostFileShouldExistWhenSelected(postFile);

            GetByIdPostFileResponse response = _mapper.Map<GetByIdPostFileResponse>(postFile);
            return response;
        }
    }
}