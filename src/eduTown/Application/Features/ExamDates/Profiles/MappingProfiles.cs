using Application.Features.ExamDates.Commands.Create;
using Application.Features.ExamDates.Commands.Delete;
using Application.Features.ExamDates.Commands.Update;
using Application.Features.ExamDates.Queries.GetById;
using Application.Features.ExamDates.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.ExamDates.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateExamDateCommand, ExamDate>();
        CreateMap<ExamDate, CreatedExamDateResponse>();

        CreateMap<UpdateExamDateCommand, ExamDate>();
        CreateMap<ExamDate, UpdatedExamDateResponse>();

        CreateMap<DeleteExamDateCommand, ExamDate>();
        CreateMap<ExamDate, DeletedExamDateResponse>();

        CreateMap<ExamDate, GetByIdExamDateResponse>();

        CreateMap<ExamDate, GetListExamDateListItemDto>();
        CreateMap<IPaginate<ExamDate>, GetListResponse<GetListExamDateListItemDto>>();
    }
}