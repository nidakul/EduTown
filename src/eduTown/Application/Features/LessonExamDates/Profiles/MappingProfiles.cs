using Application.Features.LessonExamDates.Commands.Create;
using Application.Features.LessonExamDates.Commands.Delete;
using Application.Features.LessonExamDates.Commands.Update;
using Application.Features.LessonExamDates.Queries.GetById;
using Application.Features.LessonExamDates.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.LessonExamDates.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateLessonExamDateCommand, LessonExamDate>();
        CreateMap<LessonExamDate, CreatedLessonExamDateResponse>();

        CreateMap<UpdateLessonExamDateCommand, LessonExamDate>();
        CreateMap<LessonExamDate, UpdatedLessonExamDateResponse>();

        CreateMap<DeleteLessonExamDateCommand, LessonExamDate>();
        CreateMap<LessonExamDate, DeletedLessonExamDateResponse>();

        CreateMap<LessonExamDate, GetByIdLessonExamDateResponse>();

        CreateMap<LessonExamDate, GetListLessonExamDateListItemDto>();
        CreateMap<IPaginate<LessonExamDate>, GetListResponse<GetListLessonExamDateListItemDto>>();
    }
}