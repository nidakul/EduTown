using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Commands.UpdateFromAuth;
using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Queries.GetCertificatesByUserId;
using Application.Features.Users.Queries.GetList;
using Application.Features.Users.Queries.GetStudentByUserId;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using OtpNet;
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
            //.ForMember(u => u.SchoolName, opt => opt.MapFrom(u=>u.School.Name))

            .ReverseMap();

        CreateMap<User, GetCertificatesByUserIdResponse>()
            .ForMember(u => u.Id, opt => opt.MapFrom(u => u.Id))
            .ForMember(dest => dest.Certificates, opt => opt.MapFrom(src => src.UserCertificates.Select(u=> new CertificateDto
            {
                Id = u.Id,
                CertificateName = u.Certificate.Name,
                //ClassroomName = u.Classroom.Name
            }).ToList())).ReverseMap();

        CreateMap<IPaginate<User>, GetListResponse<GetListUserListItemDto>>().ReverseMap();
    }
}