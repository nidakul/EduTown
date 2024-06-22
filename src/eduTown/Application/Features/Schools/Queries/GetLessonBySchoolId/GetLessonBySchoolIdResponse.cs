using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.Schools.Queries.GetLessonBySchoolId
{
    public class GetLessonBySchoolIdResponse : IResponse
    {
        public string SchoolName { get; set; }
        public List<string> LessonName { get; set; }

        public GetLessonBySchoolIdResponse()
        {
        }

        public GetLessonBySchoolIdResponse(string schoolName, List<string> lessonName): this()
        {
            SchoolName = schoolName;
            LessonName = lessonName;
        }
    }
}


