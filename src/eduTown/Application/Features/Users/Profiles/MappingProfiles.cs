using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Commands.UpdateFromAuth;
using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Queries.GetCertificatesByUserId;
using Application.Features.Users.Queries.GetInstructorByUserId;
using Application.Features.Users.Queries.GetList;
using Application.Features.Users.Queries.GetStudentByUserId;
using Application.Features.Users.Queries.GetStudentExamDateByUserId;
using Application.Features.Users.Queries.GetStudentGradesByUserId;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using OtpNet;
using System.Diagnostics;
using static Application.Features.Users.Queries.GetStudentByUserId.GetStudentByUserIdResponse;

namespace Application.Features.Users.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, CreateUserCommand>().ReverseMap();
        CreateMap<User, CreatedUserResponse>().ReverseMap();
        CreateMap<User, UpdateUserCommand>().ReverseMap();
        CreateMap<User, UpdatedUserResponse>().ReverseMap();
        CreateMap<User, UpdateUserFromAuthCommand>().ReverseMap();
        CreateMap<User, UpdatedUserFromAuthResponse>().ReverseMap();
        CreateMap<User, DeleteUserCommand>().ReverseMap();
        CreateMap<User, DeletedUserResponse>().ReverseMap();
        CreateMap<User, GetByIdUserResponse>().ReverseMap();
        CreateMap<User, GetListUserListItemDto>().ReverseMap();
        CreateMap<User, GetStudentByUserIdResponse>()
            .ForMember(u => u.StudentNo, opt => opt.MapFrom(u => u.Student.StudentNo))
            .ForMember(u => u.Id, opt => opt.MapFrom(u => u.Id))
            .ForMember(u => u.SchoolName, opt => opt.MapFrom(u => u.School.Name))
            .ForMember(u => u.SchoolId, opt => opt.MapFrom(u => u.School.Id))
            .ForMember(u => u.ClassroomId, opt => opt.MapFrom(u => u.Student.Classroom.Id))
            .ForMember(u => u.ClassroomName, opt => opt.MapFrom(u => u.Student.Classroom.Name))
            .ReverseMap();

        CreateMap<User, GetInstructorByUserIdResponse>()
            .ForMember(u => u.Id, opt => opt.MapFrom(u => u.Id))
            .ForMember(u => u.Department, opt => opt.MapFrom(u => u.Instructor.Department))
            .ForMember(u => u.SchoolName, opt => opt.MapFrom(u => u.School.Name))
            .ReverseMap();

        CreateMap<User, GetCertificatesByUserIdResponse>()
            .ForMember(u => u.Id, opt => opt.MapFrom(u => u.Id))
            .ForMember(dest => dest.Certificates, opt => opt.MapFrom(src => src.UserCertificates.Select(u => new CertificateDto
            {
                Id = u.Id,
                CertificateName = u.Certificate.Name,
                //ClassroomName = u.Classroom.Name, 
                Year = u.Year,
                Semester = u.Semester
            }).ToList())).ReverseMap();


        CreateMap<User, GetStudentGradesByUserIdResponse>()
    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
    .ForMember(dest => dest.StudentGrades, opt => opt.MapFrom(src => src.StudentGrades
.GroupBy(sg => new { sg.Classroom.Id, sg.Classroom.Name }).Select(g => new StudentGradesByClassroomDto
{
    ClassroomId = g.Key.Id,
    ClassroomName = g.Key.Name,
    TermNames = g.GroupBy(cl => new { cl.Term.Id, cl.Term.Name })
                .Select(gl => new StudentGradesByTermDto
                {
                    TermId = gl.Key.Id,
                    TermName = gl.Key.Name,
                    Lessons = gl.GroupBy(lesson => lesson.Lesson.Name)
                        .Select(lessonGroup => new StudentGradesByLessonDto
                        {
                            LessonName = lessonGroup.Key,
                            Grades = lessonGroup.GroupBy(grade => grade.GradeType.Name)
                                .Select(gradeGroup => new StudentGradeDetailsDto
                                {
                                    GradeTypeName = gradeGroup.Key,
                                    GradesDto = gradeGroup.Select(gr => new GradeDto
                                    {
                                        ExamCount = gr.ExamCount,
                                        Grade = gr.Grade
                                    }).ToList()
                                }).ToList()
                        }).ToList()
                }).ToList()
}).ToList()
    ))
    .ReverseMap();


        //   CreateMap<User, GetStudentExamDateByUserIdResponse>()
        //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        //.ForMember(dest => dest.StudentExamDates, opt => opt.MapFrom(src => src.UserLessons
        //    .SelectMany(ul => ul.Lesson.LessonExamDate
        //        .Select(led => new StudentExamDateDto
        //        {
        //            LessonName = ul.Lesson.Name,
        //            ExamType = led.ExamDate.ExamType,
        //            StartDate = led.ExamDate.StartDate,
        //            EndDate = led.ExamDate.EndDate
        //        })
        //    )
        //    .GroupBy(se => se.LessonName)
        //    .SelectMany(g => g)
        //    .ToList()))
        //.ReverseMap();



        CreateMap<IPaginate<User>, GetListResponse<GetListUserListItemDto>>().ReverseMap();
    }
}





//CreateMap<User, GetStudentGradesByUserIdResponse>()
//      .ForMember(u => u.Id, opt => opt.MapFrom(u => u.Id))
//      .ForMember(dest => dest.StudentGrades, opt => opt.MapFrom(
//          src => src.StudentGrades.GroupBy(sg => sg.Lesson.Name)
//              .Select(g => new StudentGradesByLessonDto
//              { 
//                  LessonName = g.Key,
//                  Grades = g.OrderBy(ec => ec.ExamCount)
//                  .GroupBy(grade => grade.GradeType.Name)
//                            .Select(grp => new StudentGradeDetailsDto
//                            {
//                                GradeTypeName = grp.Key,
//                                GradesDto = grp.Select(g => new GradeDto
//                                {
//                                    ExamCount = g.ExamCount,
//                                    Grade = g.Grade
//                                }).ToList()
//                            }).ToList()
//              }).ToList()
//      ))
//      .ReverseMap();