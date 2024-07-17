using Application.Features.SchoolClasses.Queries.GetLessonsBySchoolIdAndClassId;
using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.SchoolClasses.GetBranchesBySchoolIdAndClassId
{
    public class GetBranchesBySchoolIdAndClassIdResponse : IResponse
    {
        public string SchoolName { get; set; }
        public string ClassroomName { get; set; }
        public List<BranchDto> Branches { get; set; }

        public GetBranchesBySchoolIdAndClassIdResponse()
        {
        }
    }

    public class BranchDto
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
    }
} 

