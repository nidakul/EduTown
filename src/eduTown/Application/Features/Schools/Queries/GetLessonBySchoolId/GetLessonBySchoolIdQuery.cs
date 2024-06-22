using Application.Features.Schools.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
namespace Application.Features.Schools.Queries.GetLessonBySchoolId
{
    public class GetLessonBySchoolIdQuery: IRequest<GetLessonBySchoolIdResponse>
    {
        public int Id { get; set; }
        public class GetLessonBySchoolIdQueryHandler : IRequestHandler<GetLessonBySchoolIdQuery, GetLessonBySchoolIdResponse>
        {
            private readonly ISchoolRepository _schoolRepository;
            private readonly IMapper _mapper;
            private readonly SchoolBusinessRules _schoolBusinessRules;

            public GetLessonBySchoolIdQueryHandler(ISchoolRepository schoolRepository, IMapper mapper, SchoolBusinessRules schoolBusinessRules)
            {
                _schoolRepository = schoolRepository;
                _mapper = mapper;
                _schoolBusinessRules = schoolBusinessRules;
            }
            public async Task<GetLessonBySchoolIdResponse> Handle(GetLessonBySchoolIdQuery request, CancellationToken cancellationToken)
            {
                School? school = await _schoolRepository.GetAsync(predicate: b => b.Id.Equals(request.Id),
                    include: b => b.Include(b => b.SchoolLessons).ThenInclude(b => b.Lesson),
                    enableTracking: false,
                    cancellationToken: cancellationToken);
                await _schoolBusinessRules.SchoolShouldExistWhenSelected(school);

                GetLessonBySchoolIdResponse response = _mapper.Map<GetLessonBySchoolIdResponse>(school);
                return response;
            }
        }
    }
}


