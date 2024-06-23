using Domain.Entities;
using Microsoft.AspNetCore.Http;
using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.SchoolLessons.Queries.GetLessonBySchoolIdAndClassId
{
    public class GetLessonBySchoolIdAndClassIdResponse : IResponse
    {
        public string SchoolName { get; set; }
        public string ClassroomName { get; set; }
        public List<string> LessonName { get; set; }

        public GetLessonBySchoolIdAndClassIdResponse()
        {
        }

        public GetLessonBySchoolIdAndClassIdResponse(string schoolName, string classroomName, List<string> lessonName): this()
        {
            SchoolName = schoolName;
            ClassroomName = classroomName; 
            LessonName = lessonName;
        } 
    }
} 
