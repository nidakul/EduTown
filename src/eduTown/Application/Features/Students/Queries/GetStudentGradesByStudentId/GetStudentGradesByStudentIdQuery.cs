using Application.Features.Students.Rules;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;

namespace Application.Features.Students.Queries.GetStudentGradesByStudentId
{
    public class GetStudentGradesByStudentIdQuery : IRequest<GetStudentGradesByStudentIdResponse>
    {
        public Guid Id { get; set; }

        public class GetStudentGradesByStudentIdQueryHandler : IRequestHandler<GetStudentGradesByStudentIdQuery, GetStudentGradesByStudentIdResponse>
        {
            private readonly IMapper _mapper;
            private readonly IStudentRepository _studentRepository;
            private readonly StudentBusinessRules _studentBusinessRules;

            public GetStudentGradesByStudentIdQueryHandler(IMapper mapper, IStudentRepository studentRepository, StudentBusinessRules studentBusinessRules)
            {
                _mapper = mapper;
                _studentRepository = studentRepository;
                _studentBusinessRules = studentBusinessRules;
            }

            public async Task<GetStudentGradesByStudentIdResponse> Handle(GetStudentGradesByStudentIdQuery request, CancellationToken cancellationToken)
            {
                Student? student = await _studentRepository.GetAsync(predicate: u => u.Id.Equals(request.Id),
                   include: u => u.Include(u => u.StudentGrades).ThenInclude(u => u.Lesson)
                   .Include(u => u.StudentGrades).ThenInclude(u => u.GradeType)
                   .Include(u => u.StudentGrades).ThenInclude(u => u.Term)
                   .Include(u => u.StudentGrades).ThenInclude(u => u.Classroom),
                   //.Include(u => u.Classroom),
                   enableTracking: false,
                   cancellationToken: cancellationToken);
                await _studentBusinessRules.StudentShouldExistWhenSelected(student);

                GetStudentGradesByStudentIdResponse response = _mapper.Map<GetStudentGradesByStudentIdResponse>(student);
                return response;
            }
        }
    }
}

