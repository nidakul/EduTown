using Application.Features.Classrooms.Rules;
using Application.Features.SchoolLessons.Rules;
using Application.Features.Schools.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
namespace Application.Features.SchoolLessons.Queries.GetLessonBySchoolIdAndClassId
{
    public class GetLessonBySchoolIdAndClassIdQuery : IRequest<GetLessonBySchoolIdAndClassIdResponse>
    {
        public int SchoolId { get; set; }
        public int ClassroomId { get; set; }

        public class GetLessonBySchoolIdAndClassIdQueryHandler : IRequestHandler<GetLessonBySchoolIdAndClassIdQuery, GetLessonBySchoolIdAndClassIdResponse>
        {
            private readonly ISchoolLessonRepository _schoolLessonRepository;
            private readonly IMapper _mapper;
            private readonly SchoolLessonBusinessRules _schoolLessonBusinessRules;
            private readonly SchoolBusinessRules _schoolBusinessRules;
            private readonly ClassroomBusinessRules _classroomBusinessRules;

            public GetLessonBySchoolIdAndClassIdQueryHandler(ISchoolLessonRepository schoolLessonRepository, IMapper mapper, SchoolLessonBusinessRules schoolLessonBusinessRules, SchoolBusinessRules schoolBusinessRules, ClassroomBusinessRules classroomBusinessRules)
            {
                _schoolLessonRepository = schoolLessonRepository;
                _mapper = mapper;
                _schoolLessonBusinessRules = schoolLessonBusinessRules;
                _schoolBusinessRules = schoolBusinessRules;
                _classroomBusinessRules = classroomBusinessRules;
            }

            public async Task<GetLessonBySchoolIdAndClassIdResponse> Handle(GetLessonBySchoolIdAndClassIdQuery request, CancellationToken cancellationToken)
            {
                SchoolLesson? schoolLesson = await _schoolLessonRepository.GetAsync(predicate: sl => sl.SchoolId.Equals(request.SchoolId) && sl.Classrooms.Any(cl => cl.Id.Equals(request.ClassroomId)),
                    include: sl => sl.Include(sl => sl.School)
                    .Include(sl => sl.Lesson)
                    .Include(sl => sl.Classrooms),  
                    enableTracking: false,
                    cancellationToken: cancellationToken);
                //await _schoolLessonBusinessRules.SchoolLessonShouldExistWhenSelected(schoolLesson);
                await _schoolBusinessRules.SchoolIdShouldExistWhenSelected(request.SchoolId, cancellationToken);
                await _classroomBusinessRules.ClassroomIdShouldExistWhenSelected(request.ClassroomId, cancellationToken);

                GetLessonBySchoolIdAndClassIdResponse response = _mapper.Map<GetLessonBySchoolIdAndClassIdResponse>(schoolLesson);
                return response;
            }
            
        }
    }
}

