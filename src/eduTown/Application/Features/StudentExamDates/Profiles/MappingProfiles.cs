using Application.Features.StudentExamDates.Commands.Create;
using Application.Features.StudentExamDates.Commands.Delete;
using Application.Features.StudentExamDates.Commands.Update;
using Application.Features.StudentExamDates.Queries.GetById;
using Application.Features.StudentExamDates.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.StudentExamDates.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateStudentExamDateCommand, StudentExamDate>();
        CreateMap<StudentExamDate, CreatedStudentExamDateResponse>();

        CreateMap<UpdateStudentExamDateCommand, StudentExamDate>();
        CreateMap<StudentExamDate, UpdatedStudentExamDateResponse>();

        CreateMap<DeleteStudentExamDateCommand, StudentExamDate>();
        CreateMap<StudentExamDate, DeletedStudentExamDateResponse>();

        CreateMap<StudentExamDate, GetByIdStudentExamDateResponse>();

        CreateMap<StudentExamDate, GetListStudentExamDateListItemDto>();
        CreateMap<IPaginate<StudentExamDate>, GetListResponse<GetListStudentExamDateListItemDto>>();
    }
}