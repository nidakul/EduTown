using Application.Features.UserCertificates.Commands.Create;
using Application.Features.UserCertificates.Commands.Delete;
using Application.Features.UserCertificates.Commands.Update;
using Application.Features.UserCertificates.Queries.GetById;
using Application.Features.UserCertificates.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.UserCertificates.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateUserCertificateCommand, UserCertificate>();
        CreateMap<UserCertificate, CreatedUserCertificateResponse>();

        CreateMap<UpdateUserCertificateCommand, UserCertificate>();
        CreateMap<UserCertificate, UpdatedUserCertificateResponse>();

        CreateMap<DeleteUserCertificateCommand, UserCertificate>();
        CreateMap<UserCertificate, DeletedUserCertificateResponse>();

        CreateMap<UserCertificate, GetByIdUserCertificateResponse>();

        CreateMap<UserCertificate, GetListUserCertificateListItemDto>();
        CreateMap<IPaginate<UserCertificate>, GetListResponse<GetListUserCertificateListItemDto>>();
    }
}