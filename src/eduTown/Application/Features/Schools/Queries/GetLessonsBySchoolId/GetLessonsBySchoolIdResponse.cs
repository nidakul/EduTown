using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.Schools.Queries.GetLessonsBySchoolId
{
    public class GetLessonsBySchoolIdResponse : IResponse
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public List<string> LessonName { get; set; }

        public GetLessonsBySchoolIdResponse()
        {
        }

        public GetLessonsBySchoolIdResponse(int id, string schoolName, List<string> lessonName) : this()
        {
            Id = id;
            SchoolName = schoolName;
            LessonName = lessonName;
        }
    }
}


    



