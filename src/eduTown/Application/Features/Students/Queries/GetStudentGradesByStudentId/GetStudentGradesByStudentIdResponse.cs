using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.Students.Queries.GetStudentGradesByStudentId
{
    public class GetStudentGradesByStudentIdResponse : IResponse
    {
        public Guid Id { get; set; }
        public List<StudentGradesByClassroomDto> StudentGrades { get; set; }

        public GetStudentGradesByStudentIdResponse()
        {
        }
    }
    public class StudentGradesByClassroomDto
    {
        public int ClassroomId { get; set; }
        public string ClassroomName { get; set; }
        public List<StudentGradesByTermDto> TermNames { get; set; }
    }

    public class StudentGradesByTermDto
    {
        public int TermId { get; set; }
        public string TermName { get; set; }
        public List<StudentGradesByLessonDto> Lessons { get; set; }
    }

    public class StudentGradesByLessonDto
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public List<StudentGradeDetailsDto> Grades { get; set; }
    }

    public class StudentGradeDetailsDto
    {
        public int GradeTypeId { get; set; }
        public string GradeTypeName { get; set; }
        public List<GradeDto> GradesDto { get; set; }

    }

    public class GradeDto
    {
        public int ExamCount { get; set; }
        public double Grade { get; set; }
    }

}