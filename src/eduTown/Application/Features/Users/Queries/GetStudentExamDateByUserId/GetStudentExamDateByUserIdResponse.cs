using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.Users.Queries.GetStudentExamDateByUserId
{
    public class GetStudentExamDateByUserIdResponse : IResponse
    {
        public Guid Id { get; set; }
        public List<StudentExamDateDto> StudentExamDates { get; set; }
        

        public GetStudentExamDateByUserIdResponse()
        {
        }


    }

    public class StudentExamDateDto
    {
        public string LessonName { get; set; }
        public string ExamType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}


