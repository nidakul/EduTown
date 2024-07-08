using Application.Features.Students.Commands.Create;
using Application.Features.Students.Commands.Delete;
using Application.Features.Students.Commands.Update;
using Application.Features.Students.Queries.GetById;
using Application.Features.Students.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Students.Queries.GetStudentDetail;

namespace Application.Features.Students.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateStudentCommand, Student>();
        CreateMap<Student, CreatedStudentResponse>();

        CreateMap<UpdateStudentCommand, Student>();
        CreateMap<Student, UpdatedStudentResponse>();

        CreateMap<DeleteStudentCommand, Student>();
        CreateMap<Student, DeletedStudentResponse>();

        CreateMap<Student, GetByIdStudentResponse>();

        CreateMap<Student, GetListStudentListItemDto>();
        CreateMap<IPaginate<Student>, GetListResponse<GetListStudentListItemDto>>();

        CreateMap<IPaginate<Student>, GetListResponse<GetListStudentDetailResponse>>();
        CreateMap<Student, GetListStudentDetailResponse>()
            .ForMember(s => s.SchoolId, opt => opt.MapFrom(s => s.User.School.Id))
            .ForMember(s => s.ClassroomId, opt => opt.MapFrom(s => s.Classroom.Name))
            .ForMember(s => s.SchoolName, opt => opt.MapFrom(s => s.User.School.Name))
            .ForMember(s => s.NationalIdentity, opt => opt.MapFrom(s => s.User.NationalIdentity))
            .ForMember(s => s.FirstName, opt => opt.MapFrom(s => s.User.FirstName))
            .ForMember(s => s.LastName, opt => opt.MapFrom(s => s.User.LastName))
            .ForMember(s => s.Email, opt => opt.MapFrom(s => s.User.Email))
            .ForMember(s => s.ImageUrl, opt => opt.MapFrom(s => s.User.ImageUrl))
            .ForMember(s => s.Gender, opt => opt.MapFrom(s => s.User.Gender))
            .ForMember(s => s.ClassroomName, opt => opt.MapFrom(s => s.Classroom.Name))

            .ReverseMap(); 
    }
}