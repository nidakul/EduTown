using Application.Features.Posts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
namespace Application.Features.Posts.Queries.GetDetail
{
    public class GetDetailByPostIdQuery : IRequest<GetDetailByPostIdResponse>
    {
        public int Id { get; set; }

        public class GetDetailByPostIdQueryHandler : IRequestHandler<GetDetailByPostIdQuery, GetDetailByPostIdResponse>
        {
            private readonly IMapper _mapper;
            private readonly IPostRepository _postRepository;
            private readonly PostBusinessRules _postBusinessRules;

            public GetDetailByPostIdQueryHandler(IMapper mapper, IPostRepository postRepository, PostBusinessRules postBusinessRules)
            {
                _mapper = mapper;
                _postRepository = postRepository;
                _postBusinessRules = postBusinessRules;
            }
            public async Task<GetDetailByPostIdResponse> Handle(GetDetailByPostIdQuery request, CancellationToken cancellationToken)
            {
                Post? post = await _postRepository.GetAsync(predicate: p => p.Id.Equals(request.Id),
                    include: p => p.Include(p => p.User).ThenInclude(p => p.Student.Classroom)
                    .Include(p => p.User.School)
                    .Include(p => p.User)
                    .Include(p => p.User.Student.Branch),
                    enableTracking: false,
                   cancellationToken: cancellationToken);
                await _postBusinessRules.PostShouldExistWhenSelected(post);

                GetDetailByPostIdResponse response = _mapper.Map<GetDetailByPostIdResponse>(post);
                return response;

            }
        }
    }
}

