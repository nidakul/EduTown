using Application.Features.Posts.Queries.GetPostsBySchoolIdClassIdBranchId;
using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.Students.Queries.GetListStudentsSchoolIdClassIdBranchId
{
    public class GetListStudentsSchoolIdClassIdBranchIdResponse: IResponse
    {
        public List<StudentDto> Students { get; set; }

    }
}


public class StudentDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
