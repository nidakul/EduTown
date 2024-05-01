using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
namespace Application.Features.Users.Queries.GetStudentGradesByUserId
{
    public class GetStudentGradesByUserIdResponse : IResponse
    {
        public Guid Id { get; set; }
        public List<StudentGradesByLessonDto> StudentGrades { get; set; }


        public GetStudentGradesByUserIdResponse()
        {
        }
    }

    public class StudentGradesByLessonDto
    {
        public string LessonName { get; set; }
        public List<StudentGradeDetailsDto> Grades { get; set; }
    }

    public class StudentGradeDetailsDto
    {
        public string GradeTypeName { get; set; }
        public List<GradeDto> GradesDto { get; set; }

    }

    public class GradeDto
    {
        public int GradeNumber { get; set; }
        public double Grade { get; set; }
    }
}




