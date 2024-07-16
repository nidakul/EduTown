using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.SchoolClasses.Queries.GetLessonsBySchoolIdAndClassId
{
    public class GetLessonsBySchoolIdAndClassIdResponse : IResponse
    {
        public string SchoolName { get; set; }
        public string ClassroomName { get; set; }
        public List<LessonDto> Lessons { get; set; }

        public GetLessonsBySchoolIdAndClassIdResponse()
        {
        }
    }

    public class LessonDto
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
    }
}

