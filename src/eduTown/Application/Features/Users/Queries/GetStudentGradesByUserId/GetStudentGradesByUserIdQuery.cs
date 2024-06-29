using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
namespace Application.Features.Users.Queries.GetStudentGradesByUserId
{
    public class GetStudentGradesByUserIdQuery : IRequest<GetStudentGradesByUserIdResponse>
    {
        public Guid Id { get; set; }

        public class GetStudentGradesByUserIdQueryHandler : IRequestHandler<GetStudentGradesByUserIdQuery, GetStudentGradesByUserIdResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;
             
            public GetStudentGradesByUserIdQueryHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<GetStudentGradesByUserIdResponse> Handle(GetStudentGradesByUserIdQuery request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(predicate: u => u.Id.Equals(request.Id),
                    include: u => u.Include(u => u.StudentGrades).ThenInclude(u => u.Lesson)
                    .Include(u => u.StudentGrades).ThenInclude(u => u.GradeType)
                    .Include(u => u.StudentGrades).ThenInclude(u => u.Classroom)
                    .Include(u => u.StudentGrades).ThenInclude(u => u.Term),
                    enableTracking: false,
                    cancellationToken: cancellationToken); 

                await _userBusinessRules.UserShouldBeExistsWhenSelected(user);
                
                GetStudentGradesByUserIdResponse response = _mapper.Map<GetStudentGradesByUserIdResponse>(user);
                return response;
            }
        }
    } 
}

