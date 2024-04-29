using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.Users.Queries.GetStudentGradesByUserId
{
    public class GetStudentGradesByUserIdResponse: IResponse
    {
        public Guid Id { get; set; }
        public List<StudentGradeDto> StudentGrades { get; set; }


        public GetStudentGradesByUserIdResponse()
        {
        }
    }

    public class StudentGradeDto
    {
        public int Id { get; set; }
        public string LessonName { get; set; }
        public string GradeTypeName { get; set; }
        public int ExamCount { get; set; }
        public double Grade { get; set; }

    }
}


