using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.SchoolTypes.Queries.GetClassesBySchoolTypeId
{
    public class GetClassesBySchoolTypeIdResponse : IResponse
    {
        public List<ClassInfo> Classes { get; set; }

        public GetClassesBySchoolTypeIdResponse()
        {
        }
    }

    public class ClassInfo
    {
        public int ClassroomId { get; set; }
        public string ClassroomName { get; set; }
    }
}

