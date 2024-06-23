using Application.Features.Classrooms.Rules;
using Application.Features.SchoolClasses.Rules;
using Application.Features.Schools.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
namespace Application.Features.SchoolClasses.Queries.GetLessonsBySchoolIdAndClassId
{
    public class GetLessonsBySchoolIdAndClassIdQuery : IRequest<GetLessonsBySchoolIdAndClassIdResponse>
    {
        public int SchoolId { get; set; }
        public int ClassroomId { get; set; }
    }

    public class GetLessonsBySchoolIdAndClassIdQueryHandler : IRequestHandler<GetLessonsBySchoolIdAndClassIdQuery, GetLessonsBySchoolIdAndClassIdResponse>
    {
        private readonly ISchoolClassRepository _schoolClassRepository;
        private readonly IMapper _mapper;
        private readonly SchoolClassBusinessRules _schoolClassBusinessRules;
        private readonly SchoolBusinessRules _schoolBusinessRules;
        private readonly ClassroomBusinessRules _classroomBusinessRules;

        public GetLessonsBySchoolIdAndClassIdQueryHandler(ISchoolClassRepository schoolClassRepository, IMapper mapper, SchoolClassBusinessRules schoolClassBusinessRules, SchoolBusinessRules schoolBusinessRules, ClassroomBusinessRules classroomBusinessRules)
        {
            _schoolClassRepository = schoolClassRepository;
            _mapper = mapper;
            _schoolClassBusinessRules = schoolClassBusinessRules;
            _schoolBusinessRules = schoolBusinessRules;
            _classroomBusinessRules = classroomBusinessRules;
        }
        public async Task<GetLessonsBySchoolIdAndClassIdResponse> Handle(GetLessonsBySchoolIdAndClassIdQuery request, CancellationToken cancellationToken)
        {
            SchoolClass? schoolClass = await _schoolClassRepository.GetAsync(predicate: sc => sc.SchoolId.Equals(request.SchoolId) && sc.ClassroomId.Equals(request.ClassroomId),
              include: sc => sc.Include(sc => sc.School)
                    .Include(sc => sc.Classroom)
                    .Include(sc => sc.SchoolClassLessons).ThenInclude(sc => sc.Lesson),
                    enableTracking: false,
                    cancellationToken: cancellationToken);

            await _schoolBusinessRules.SchoolIdShouldExistWhenSelected(request.SchoolId, cancellationToken);
            await _classroomBusinessRules.ClassroomIdShouldExistWhenSelected(request.ClassroomId, cancellationToken);


            GetLessonsBySchoolIdAndClassIdResponse response = _mapper.Map<GetLessonsBySchoolIdAndClassIdResponse>(schoolClass);
            return response;
        }

    }

}



