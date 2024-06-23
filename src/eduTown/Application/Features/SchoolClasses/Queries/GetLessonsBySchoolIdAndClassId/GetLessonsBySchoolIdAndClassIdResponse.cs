using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.SchoolClasses.Queries.GetLessonsBySchoolIdAndClassId
{
    public class GetLessonsBySchoolIdAndClassIdResponse : IResponse
    {
        public string SchoolName { get; set; }
        public string ClassroomName { get; set; }
        public List<string> LessonName { get; set; }

        public GetLessonsBySchoolIdAndClassIdResponse()
        {
        }
    }
}

