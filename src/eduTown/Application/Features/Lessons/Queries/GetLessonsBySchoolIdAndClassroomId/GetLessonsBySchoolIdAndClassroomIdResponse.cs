using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.Lessons.Queries.GetLessonsBySchoolIdAndClassroomId
{
    public class GetLessonsBySchoolIdAndClassroomIdResponse: IResponse
    {
        public int ClassroomId { get; set; }
        public int SchoolId { get; set; }
        public List<string> LessonName { get; set; }

        public GetLessonsBySchoolIdAndClassroomIdResponse()
        {
        }

        public GetLessonsBySchoolIdAndClassroomIdResponse(int classroomId, int schoolId, List<string> lessonName)
        {
            ClassroomId = classroomId;
            SchoolId = schoolId;
            LessonName = lessonName;
        }
    }
}



