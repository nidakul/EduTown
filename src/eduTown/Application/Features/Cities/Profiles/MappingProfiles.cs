using Application.Features.Cities.Commands.Create;
using Application.Features.Cities.Commands.Delete;
using Application.Features.Cities.Commands.Update;
using Application.Features.Cities.Queries.GetById;
using Application.Features.Cities.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Cities.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCityCommand, City>();
        CreateMap<City, CreatedCityResponse>();

        CreateMap<UpdateCityCommand, City>();
        CreateMap<City, UpdatedCityResponse>();

        CreateMap<DeleteCityCommand, City>();
        CreateMap<City, DeletedCityResponse>();

        CreateMap<City, GetByIdCityResponse>();

        CreateMap<City, GetListCityListItemDto>();
        CreateMap<IPaginate<City>, GetListResponse<GetListCityListItemDto>>();
    }
}