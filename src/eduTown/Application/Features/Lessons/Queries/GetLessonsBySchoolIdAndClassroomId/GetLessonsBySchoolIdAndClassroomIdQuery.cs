using Application.Features.Classrooms.Rules;
using Application.Features.LessonClassrooms.Rules;
using Application.Features.Schools.Rules;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
namespace Application.Features.Lessons.Queries.GetLessonsBySchoolIdAndClassroomId
{
    public class GetLessonsBySchoolIdAndClassroomIdQuery : IRequest<GetLessonsBySchoolIdAndClassroomIdResponse>
    {
        public int ClassroomId { get; set; }
        public int SchoolId { get; set; }

        //public class GetLessonsBySchoolIdAndClassroomIdQueryHandler : IRequestHandler<GetLessonsBySchoolIdAndClassroomIdQuery, GetLessonsBySchoolIdAndClassroomIdResponse>
        //{
        //    private readonly ILessonClassroomRepository _lessonClassroomRepository;
        //    private readonly IMapper _mapper;
        //    private readonly LessonClassroomBusinessRules _lessonClassroomBusinessRules;

        //    public async Task<GetLessonsBySchoolIdAndClassroomIdResponse> Handle(GetLessonsBySchoolIdAndClassroomIdQuery request, CancellationToken cancellationToken)
        //    {
        //        LessonClassroom? lessonClassroom = await _lessonClassroomRepository.GetAsync(predicate: lc => (lc.ClassroomId == request.ClassroomId) && (lc.LessonId == request.)
        //    }
        //}
    }
}

