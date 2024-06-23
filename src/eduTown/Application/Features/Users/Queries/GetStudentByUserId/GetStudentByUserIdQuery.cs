using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
namespace Application.Features.Users.Queries.GetStudentByUserId
{
    public class GetStudentByUserIdQuery : IRequest<GetStudentByUserIdResponse>
    {
        public Guid Id { get; set; }

        public class GetStudentByUserIdQueryHandler : IRequestHandler<GetStudentByUserIdQuery, GetStudentByUserIdResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public GetStudentByUserIdQueryHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }
            public async Task<GetStudentByUserIdResponse> Handle(GetStudentByUserIdQuery request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(predicate: b => b.Id.Equals(request.Id),
                    include: b => b.Include(b => b.Student)
                    .Include(b=>b.School)
                    .Include(b=>b.UserCertificates).ThenInclude(b=>b.Certificate)
                    .Include(b=>b.School).ThenInclude(b=>b.SchoolClasses).ThenInclude(b => b.Classroom),
                    enableTracking: false,
                    cancellationToken: cancellationToken);
                await _userBusinessRules.UserShouldBeExistsWhenSelected(user);

                GetStudentByUserIdResponse response = _mapper.Map<GetStudentByUserIdResponse>(user);
                return response;
            }
        }
    }
}

