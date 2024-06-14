using Application.Features.Users.Queries.GetStudentByUserId;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
namespace Application.Features.Users.Queries.GetInstructorByUserId
{
    public class GetInstructorByUserIdQuery : IRequest<GetInstructorByUserIdResponse>
    {
        public Guid Id { get; set; }

        public class GetInstructorByUserIdQueryHandler : IRequestHandler<GetInstructorByUserIdQuery, GetInstructorByUserIdResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public GetInstructorByUserIdQueryHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }
            public async Task<GetInstructorByUserIdResponse> Handle(GetInstructorByUserIdQuery request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(predicate: u => u.Id.Equals(request.Id),
                    include: u => u.Include(u => u.Instructor)
                    .Include(b => b.School),
                    enableTracking: false,
                    cancellationToken: cancellationToken);

                await _userBusinessRules.UserShouldBeExistsWhenSelected(user);
                GetInstructorByUserIdResponse response = _mapper.Map<GetInstructorByUserIdResponse>(user);
                return response;

            }
        }
    }
}

