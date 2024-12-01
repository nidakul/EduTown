using Application.Features.Posts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
namespace Application.Features.Posts.Queries.GetCommentByPostId
{
    public class GetCommentByPostIdQuery: IRequest<GetCommentByPostIdResponse>
    {
        public int Id { get; set; }

        public class GetCommentByPostIdQueryHandler : IRequestHandler<GetCommentByPostIdQuery, GetCommentByPostIdResponse>
        {
            private readonly IMapper _mapper;
            private readonly IPostRepository _postRepository;
            private readonly PostBusinessRules _postBusinessRules;

            public GetCommentByPostIdQueryHandler(IMapper mapper, IPostRepository postRepository, PostBusinessRules postBusinessRules)
            {
                _mapper = mapper;
                _postRepository = postRepository;
                _postBusinessRules = postBusinessRules;
            }

            public async Task<GetCommentByPostIdResponse> Handle(GetCommentByPostIdQuery request, CancellationToken cancellationToken)
            {
                Post? post = await _postRepository.GetAsync(predicate: p => p.Id.Equals(request.Id),
                    //include: p => p.Include(p => p.PostComments).ThenInclude(p => p.TaggedUsers)
                    include: p => p.Include(p => p.PostComments)
                    .Include(p => p.User),
                    enableTracking: false,
                    cancellationToken: cancellationToken);

                await _postBusinessRules.PostShouldExistWhenSelected(post);

                GetCommentByPostIdResponse response = _mapper.Map<GetCommentByPostIdResponse>(post);
                return response;
            }
        }
    }
}

