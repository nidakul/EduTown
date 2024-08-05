using Application.Features.Posts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Posts.Queries.GetById;

public class GetByIdPostQuery : IRequest<GetByIdPostResponse>
{
    public int Id { get; set; }

    public class GetByIdPostQueryHandler : IRequestHandler<GetByIdPostQuery, GetByIdPostResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly PostBusinessRules _postBusinessRules;

        public GetByIdPostQueryHandler(IMapper mapper, IPostRepository postRepository, PostBusinessRules postBusinessRules)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _postBusinessRules = postBusinessRules;
        }

        public async Task<GetByIdPostResponse> Handle(GetByIdPostQuery request, CancellationToken cancellationToken)
        {
            Post? post = await _postRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _postBusinessRules.PostShouldExistWhenSelected(post);

            GetByIdPostResponse response = _mapper.Map<GetByIdPostResponse>(post);
            return response;
        }
    }
}