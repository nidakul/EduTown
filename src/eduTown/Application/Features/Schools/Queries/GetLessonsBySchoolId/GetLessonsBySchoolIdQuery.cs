using Application.Features.Schools.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
namespace Application.Features.Schools.Queries.GetLessonsBySchoolId
{
    public class GetLessonsBySchoolIdQuery : IRequest<GetLessonsBySchoolIdResponse>
    {
        public int Id { get; set; }

        public class GetLessonsBySchoolIdQueryHandler : IRequestHandler<GetLessonsBySchoolIdQuery, GetLessonsBySchoolIdResponse>
        {
            private readonly IMapper _mapper;
            private readonly SchoolBusinessRules _schoolBusinessRules;
            private readonly ISchoolRepository _schoolRepository;

            public GetLessonsBySchoolIdQueryHandler(IMapper mapper, SchoolBusinessRules schoolBusinessRules, ISchoolRepository schoolRepository)
            {
                _mapper = mapper;
                _schoolBusinessRules = schoolBusinessRules;
                _schoolRepository = schoolRepository;
            }

            public async Task<GetLessonsBySchoolIdResponse> Handle(GetLessonsBySchoolIdQuery request, CancellationToken cancellationToken)
            {
                School? school = await _schoolRepository.GetAsync(predicate: s => s.Id.Equals(request.Id),
                          include: s => s.Include(s => s.SchoolClasses).ThenInclude(s => s.SchoolClassLessons).ThenInclude(s => s.Lesson),
                          enableTracking: false,
                    cancellationToken: cancellationToken
                    );
                await _schoolBusinessRules.SchoolShouldExistWhenSelected(school);
                GetLessonsBySchoolIdResponse response = _mapper.Map<GetLessonsBySchoolIdResponse>(school);
                return response;
            }
        }
    }
}

