using Application.Features.Users.Queries.GetStudentByUserId;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
namespace Application.Features.Users.Queries.GetStudentExamDateByUserId
{
    public class GetStudentExamDateByUserIdQuery : IRequest<GetStudentExamDateByUserIdResponse>
    {
        public Guid Id { get; set; }

        public class GetStudentExamDateByUserIdQueryHandler : IRequestHandler<GetStudentExamDateByUserIdQuery, GetStudentExamDateByUserIdResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public GetStudentExamDateByUserIdQueryHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }
            public async Task<GetStudentExamDateByUserIdResponse> Handle(GetStudentExamDateByUserIdQuery request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(predicate: u => u.Student.UserId.Equals(request.Id),
                    include: u => u.Include(u => u.UserLessons).ThenInclude(u => u.Lesson)
                    .Include(u=>u.Student).ThenInclude(u => u.StudentExamDates).ThenInclude(u=>u.ExamDate),
                    enableTracking: false,
                    cancellationToken: cancellationToken);
                await _userBusinessRules.UserShouldBeExistsWhenSelected(user);

                GetStudentExamDateByUserIdResponse response = _mapper.Map<GetStudentExamDateByUserIdResponse>(user);
                return response;
            }
        } 
    }
}

