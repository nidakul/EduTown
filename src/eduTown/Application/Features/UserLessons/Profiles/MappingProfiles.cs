using Application.Features.UserLessons.Commands.Create;
using Application.Features.UserLessons.Commands.Delete;
using Application.Features.UserLessons.Commands.Update;
using Application.Features.UserLessons.Queries.GetById;
using Application.Features.UserLessons.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.UserLessons.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateUserLessonCommand, UserLesson>();
        CreateMap<UserLesson, CreatedUserLessonResponse>();

        CreateMap<UpdateUserLessonCommand, UserLesson>();
        CreateMap<UserLesson, UpdatedUserLessonResponse>();

        CreateMap<DeleteUserLessonCommand, UserLesson>();
        CreateMap<UserLesson, DeletedUserLessonResponse>();

        CreateMap<UserLesson, GetByIdUserLessonResponse>();

        CreateMap<UserLesson, GetListUserLessonListItemDto>();
        CreateMap<IPaginate<UserLesson>, GetListResponse<GetListUserLessonListItemDto>>();
    }
}