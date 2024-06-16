using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.Users.Queries.GetStudentExamDateByUserId
{
    public class GetStudentExamDateByUserIdResponse : IResponse
    {
        public Guid Id { get; set; }
        public string LessonName { get; set; }
        public string ExamType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public GetStudentExamDateByUserIdResponse()
        {
        }

        public GetStudentExamDateByUserIdResponse(Guid id, string lessonName, string examType, DateTime? startDate, DateTime? endDate): this()
        {
            Id = id;
            LessonName = lessonName;
            ExamType = examType;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}


