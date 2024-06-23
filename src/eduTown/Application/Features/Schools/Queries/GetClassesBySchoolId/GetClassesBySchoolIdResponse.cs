using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.Schools.Queries.GetClassesBySchoolId
{
    public class GetClassesBySchoolIdResponse : IResponse
    {
        public string SchoolName { get; set; }
        public List<string> ClassroomName { get; set; }

        public GetClassesBySchoolIdResponse()
        {
        }

        public GetClassesBySchoolIdResponse(string schoolName, List<string> classroomName)
        {
            SchoolName = schoolName;
            ClassroomName = classroomName;
        }
    }
}


