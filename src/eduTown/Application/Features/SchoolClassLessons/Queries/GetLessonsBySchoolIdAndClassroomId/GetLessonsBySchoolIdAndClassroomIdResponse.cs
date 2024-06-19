using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.SchoolClassLessons.Queries.GetLessonsBySchoolIdAndClassroomId
{
    public class GetLessonsBySchoolIdAndClassroomIdResponse : IResponse
    {
        public string SchoolName { get; set; }
        public string ClassroomName { get; set; }
        public List<LessonDto> LessonNames { get; set; }

        public GetLessonsBySchoolIdAndClassroomIdResponse()
        {
            LessonNames = new List<LessonDto>();
        }
    }

    public class LessonDto
    {
        public string LessonName { get; set; }
    }
}




