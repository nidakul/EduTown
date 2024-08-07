using Application.Features.Posts.Commands.Create;
using Application.Features.Posts.Commands.Delete;
using Application.Features.Posts.Commands.Update;
using Application.Features.Posts.Queries.GetById;
using Application.Features.Posts.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Posts.Queries.GetCommentByPostId;
using OtpNet;
using Application.Features.Posts.Queries.GetDetail;

namespace Application.Features.Posts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePostCommand, Post>();
        CreateMap<Post, CreatedPostResponse>();

        CreateMap<UpdatePostCommand, Post>();
        CreateMap<Post, UpdatedPostResponse>();

        CreateMap<DeletePostCommand, Post>();
        CreateMap<Post, DeletedPostResponse>();

        CreateMap<Post, GetByIdPostResponse>();

        CreateMap<Post, GetListPostListItemDto>();
        CreateMap<IPaginate<Post>, GetListResponse<GetListPostListItemDto>>();

        CreateMap<Post, GetCommentByPostIdResponse>()
            .ForMember(p => p.CommenterUserId, opt => opt.MapFrom(p => p.User.Id))
            .ForMember(p => p.CommenterFirstName, opt => opt.MapFrom(p => p.User.FirstName))
            .ForMember(p => p.CommenterLastName, opt => opt.MapFrom(p => p.User.LastName))
            .ForMember(p => p.TaggedUserId, opt => opt.MapFrom(p => p.User.Id))
            .ForMember(p => p.TaggedFirstName, opt => opt.MapFrom(p => p.User.FirstName))
            .ForMember(p => p.TaggedLastName, opt => opt.MapFrom(p => p.User.LastName))
            .ReverseMap();

        CreateMap<Post, GetDetailByPostIdResponse>()
           .ForMember(p => p.AuthorUserId, opt => opt.MapFrom(p => p.User.Id))
           .ForMember(p => p.AuthorFirstName, opt => opt.MapFrom(p => p.User.FirstName))
           .ForMember(p => p.AuthorLastName, opt => opt.MapFrom(p => p.User.LastName))
           .ForMember(p => p.SchoolId, opt => opt.MapFrom(p => p.User.School.Id))
           .ForMember(p => p.SchoolName, opt => opt.MapFrom(p => p.User.School.Name))
           .ForMember(p => p.ClassroomId, opt => opt.MapFrom(p => p.User.Student.Classroom.Id))
           .ForMember(p => p.ClassroomName, opt => opt.MapFrom(p => p.User.Student.Classroom.Name))
           .ForMember(p => p.BranchId, opt => opt.MapFrom(p => p.User.Student.Branch.Id))
           .ForMember(p => p.BranchName, opt => opt.MapFrom(p => p.User.Student.Branch.Name))
           .ForMember(p => p.CreatedDate, opt => opt.MapFrom(p => p.CreatedDate))

           .ReverseMap();


    }
}



//public class GetDetailByPostIdResponse : IResponse
//{
//    //postu yayınlayan
//    public Guid AuthorUserId { get; set; }
//    public string AuthorFirstName { get; set; }
//    public string AuthorLastName { get; set; }
//    public int SchoolId { get; set; }
//    public string SchoolName { get; set; }
//    public int ClassroomId { get; set; }
//    public string ClassroomName { get; set; }
//    public int BranchId { get; set; }
//    public string BranchName { get; set; }
//    public int LikeCount { get; set; }
//    public string Message { get; set; }
//    public bool IsCommentable { get; set; }
//    public DateTime CreatedDate { get; set; }
