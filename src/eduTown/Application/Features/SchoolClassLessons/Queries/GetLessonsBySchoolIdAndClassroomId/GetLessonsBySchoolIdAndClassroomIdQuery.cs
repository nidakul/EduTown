using Application.Features.Lessons.Rules;
using Application.Features.SchoolClassLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Threading; 

namespace Application.Features.SchoolClassLessons.Queries.GetLessonsBySchoolIdAndClassroomId
{
    public class GetLessonsBySchoolIdAndClassroomIdQuery : IRequest<GetLessonsBySchoolIdAndClassroomIdResponse>
    {
        public int SchoolId { get; set; }
        public int ClassroomId { get; set; }

        public class GetLessonsBySchoolIdAndClassroomIdQueryHandler : IRequestHandler<GetLessonsBySchoolIdAndClassroomIdQuery, GetLessonsBySchoolIdAndClassroomIdResponse>
        {
            private readonly ISchoolClassLessonRepository _schoolClassLessonRepository;
            private readonly IMapper _mapper;
            private readonly SchoolClassLessonBusinessRules _schoolClassLessonBusinessRules;

            public GetLessonsBySchoolIdAndClassroomIdQueryHandler(ISchoolClassLessonRepository schoolClassLessonRepository, IMapper mapper, SchoolClassLessonBusinessRules schoolClassLessonBusinessRules)
            {
                _schoolClassLessonRepository = schoolClassLessonRepository; 
                _mapper = mapper;
                _schoolClassLessonBusinessRules = schoolClassLessonBusinessRules;
            }
            
            public async Task<GetLessonsBySchoolIdAndClassroomIdResponse> Handle(GetLessonsBySchoolIdAndClassroomIdQuery request, CancellationToken cancellationToken)
            {
                SchoolClassLesson? schoolClassLesson = await _schoolClassLessonRepository.GetAsync(
                    predicate: scl => scl.SchoolClassroom.ClassroomId == request.ClassroomId && scl.SchoolClassroom.SchoolId == request.SchoolId,
                    include: scl => scl.Include(scl => scl.SchoolClassroom.Classroom)
                    .Include(scl => scl.SchoolClassroom.School)
                    .Include(scl => scl.Lesson),
                    enableTracking: false,
                    cancellationToken: cancellationToken);

                await _schoolClassLessonBusinessRules.SchoolClassLessonShouldExistWhenSelected(schoolClassLesson);

                GetLessonsBySchoolIdAndClassroomIdResponse response = _mapper.Map<GetLessonsBySchoolIdAndClassroomIdResponse>(schoolClassLesson);
                return response;
            }
        }
    }
}

