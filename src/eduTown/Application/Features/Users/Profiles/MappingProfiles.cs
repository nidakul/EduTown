using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Commands.UpdateFromAuth;
using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Queries.GetCertificatesByUserId;
using Application.Features.Users.Queries.GetList;
using Application.Features.Users.Queries.GetStudentByUserId;
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
            .ForMember(u => u.ClassroomName, opt => opt.MapFrom(u => u.UserClassrooms.Select(sg => sg.Classroom.Name).ToList()))

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
      .ForMember(u => u.Id, opt => opt.MapFrom(u => u.Id))
      .ForMember(dest => dest.StudentGrades, opt => opt.MapFrom(
          //src => src.StudentGrades.GroupBy(sg => sg.Lesson.Name)
          src => src.StudentGrades.GroupBy(sg => sg.User.UserClassrooms.Select(sg => sg.Classroom.Name))
              .Select(g => new StudentGradesByClassroomDto
              {
                  //ClassroomName = g.Key,
                  Lessons = g.GroupBy(cl => cl.Lesson.Name)
          .Select(g => new StudentGradesByLessonDto
          { 
              LessonName = g.Key,
              Grades = g.OrderBy(ec => ec.ExamCount)
                  .GroupBy(grade => grade.GradeType.Name)
                            .Select(grp => new StudentGradeDetailsDto 
                            {
                                GradeTypeName = grp.Key,
                                GradesDto = grp.Select(g => new GradeDto
                                {
                                    ExamCount = g.ExamCount,
                                    Grade = g.Grade
                                }).ToList()
                            }).ToList()
          }).ToList()
              }).ToList()
      ))
      .ReverseMap();




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