using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.SchoolTypes.Queries.GetClassesBySchoolTypeId
{
    public class GetClassesBySchoolTypeIdResponse : IResponse
    {
        public int SchoolTypeId { get; set; }
        public string SchoolTypeName { get; set; }
        public List<string> ClassroomName { get; set; }

        public GetClassesBySchoolTypeIdResponse()
        {
        }

        public GetClassesBySchoolTypeIdResponse(int schoolTypeId, string schoolTypeName, List<string> classroomName) : this()
        {
            SchoolTypeId = schoolTypeId;
            SchoolTypeName = schoolTypeName;
            ClassroomName = classroomName;
        }
    }
}

