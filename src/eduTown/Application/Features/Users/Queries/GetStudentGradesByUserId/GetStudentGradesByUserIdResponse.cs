using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
namespace Application.Features.Users.Queries.GetStudentGradesByUserId
{
    public class GetStudentGradesByUserIdResponse : IResponse
    {
        public Guid Id { get; set; }
        public List<StudentGradesByClassroomDto> StudentGrades { get; set; }


        public GetStudentGradesByUserIdResponse()
        {
        }
    }

    public class StudentGradesByClassroomDto
    {
        public string ClassroomName { get; set; } 
        public List<StudentGradesByTermDto> TermNames { get; set; }
    }

    public class StudentGradesByTermDto
    {
        public string TermName { get; set; }
        public List<StudentGradesByLessonDto> Lessons { get; set; }
    }

    public class StudentGradesByLessonDto
    {
        public string LessonName { get; set; }
        public List<StudentGradeDetailsDto> Grades { get; set; }
    }

    public class StudentGradeDetailsDto
    {
        public string GradeTypeName { get; set; }
        //public int GradeCount { get; set; }
        public List<GradeDto> GradesDto { get; set; }

    }

    public class GradeDto
    {
        public int ExamCount { get; set; }
        public double Grade { get; set; }
    }
}




