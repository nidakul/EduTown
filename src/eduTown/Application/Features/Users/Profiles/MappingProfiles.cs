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
            .ForMember(u => u.Id, opt => opt.MapFrom(u => u.Id))
            .ForMember(u => u.StudentId, opt => opt.MapFrom(u => u.Student.Id))
            .ForMember(u => u.StudentNo, opt => opt.MapFrom(u => u.Student.StudentNo))
            .ForMember(u => u.SchoolName, opt => opt.MapFrom(u => u.School.Name))
            .ForMember(u => u.SchoolId, opt => opt.MapFrom(u => u.School.Id))
            .ForMember(u => u.ClassroomId, opt => opt.MapFrom(u => u.Student.Classroom.Id))
            .ForMember(u => u.ClassroomName, opt => opt.MapFrom(u => u.Student.Classroom.Name))
            .ForMember(u => u.BranchId, opt => opt.MapFrom(u => u.Student.Branch.Id))
            .ForMember(u => u.BranchName, opt => opt.MapFrom(u => u.Student.Branch.Name))
            .ForMember(u => u.Birthdate, opt => opt.MapFrom(u => u.Student.Birthdate))
            .ForMember(u => u.Birthplace, opt => opt.MapFrom(u => u.Student.Birthplace))
            .ReverseMap();

        CreateMap<User, GetInstructorByUserIdResponse>()
            .ForMember(u => u.Id, opt => opt.MapFrom(u => u.Id))
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

