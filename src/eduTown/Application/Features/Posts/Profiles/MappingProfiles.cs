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
using Application.Features.Posts.Queries.GetPostsBySchoolIdClassIdBranchId;

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
            .ForMember(p => p.CommenterUserId, opt => opt.MapFrom(p => p.PostComments.Select(p=> p.Post.User.Id).FirstOrDefault()))
            .ForMember(p => p.CommenterFirstName, opt => opt.MapFrom(p => p.PostComments.Select(p => p.Post.User.FirstName).FirstOrDefault()))
            .ForMember(p => p.CommenterLastName, opt => opt.MapFrom(p => p.PostComments.Select(p => p.Post.User.LastName).FirstOrDefault()))
            .ForMember(p => p.TaggedUserId, opt => opt.MapFrom(p => p.PostComments.Select(p => p.Post.User.Id).ToList()))
            .ForMember(p => p.TaggedFirstName,opt=> opt.MapFrom(p => p.PostComments.Select(p => p.Post.User.FirstName).ToList()))
            .ForMember(p => p.TaggedLastName, opt=>opt.MapFrom(p => p.PostComments.Select(p => p.Post.User.LastName).ToList()))
            .ForMember(p => p.Comments, opt => opt.MapFrom(p => p.PostComments.Select(p => p.Comment).ToList()))
            .ForMember(p => p.CommentCreatedDate, opt => opt.MapFrom(p => p.PostComments.Select(p => p.CreatedDate).FirstOrDefault()))
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

        //CreateMap<Paginate<Post>, GetPostsBySchoolIdClassIdBranchIdResponse>()

        //          .ForMember(p => p.SchoolId, opt => opt.MapFrom(p => p.User.School.Id))
        //  .ForMember(p => p.ClassroomId, opt => opt.MapFrom(p => p.User.Student.Classroom.Id))
        //  .ForMember(p => p.ClassroomName, opt => opt.MapFrom(p => p.User.Student.Classroom.Name))
        //  .ForMember(p => p.BranchId, opt => opt.MapFrom(p => p.User.Student.Branch.Id))
        //  .ForMember(p => p.BranchName, opt => opt.MapFrom(p => p.User.Student.Branch.Name))
        //  .ForMember(p => p.UserId, opt => opt.MapFrom(p => p.User.Id))
        //   .ForMember(p => p.FirstName, opt => opt.MapFrom(p => p.User.FirstName))
        //   .ForMember(p => p.LastName, opt => opt.MapFrom(p => p.User.LastName))
        //   .ForMember(p => p.ImageUrl, opt => opt.MapFrom(p => p.User.ImageUrl))
        //   .ForMember(p => p.PostId, opt => opt.MapFrom(p => p.Id))
        //   .ForMember(p => p.LikeCount, opt => opt.MapFrom(p => p.LikeCount))
        //   .ForMember(p => p.Message, opt => opt.MapFrom(p => p.Message))
        //   .ForMember(p => p.IsCommentable, opt => opt.MapFrom(p => p.IsCommentable))
        //   .ForMember(p => p.CreatedDate, opt => opt.MapFrom(p => p.CreatedDate))
        //  //.ForMember(p => p.Posts, opt => opt.MapFrom(p => p.User.Posts
        //  //.Select(p => new PostDto
        //  //{
        //  //    UserId = p.User.Id,
        //  //    FirstName = p.User.FirstName,
        //  //    LastName = p.User.LastName,
        //  //    ImageUrl = p.User.ImageUrl,
        //  //    PostId = p.Id,
        //  //    LikeCount = p.LikeCount,
        //  //    Message = p.Message,
        //  //    IsCommentable = p.IsCommentable,
        //  //    CreatedDate = p.CreatedDate
        //  //}).ToList()))
        //  .ReverseMap();

        CreateMap<Paginate<Post>, GetPostsBySchoolIdClassIdBranchIdResponse>()
            .ForMember(dest => dest.Posts, opt => opt.MapFrom(p => p.Items
            .OrderByDescending(post => post.CreatedDate)
                .Select(p => new PostDto
                {
                    UserId = p.User.Id,
                    FirstName = p.User.FirstName,
                    LastName = p.User.LastName,
                    ImageUrl = p.User.ImageUrl,
                    PostId = p.Id,
                    LikeCount = p.LikeCount,
                    Message = p.Message,
                    IsCommentable = p.IsCommentable,
                    FilePaths = p.FilePath,
                    CreatedDate = p.CreatedDate
                }).ToList()))
            .ForMember(dest => dest.SchoolId, opt => opt.MapFrom(p => p.Items.FirstOrDefault().SchoolId))
            .ForMember(dest => dest.ClassroomId, opt => opt.MapFrom(p => p.Items.FirstOrDefault().ClassroomId))
            .ForMember(dest => dest.BranchId, opt => opt.MapFrom(p => p.Items.FirstOrDefault().BranchId))
            .ForMember(dest => dest.ClassroomName, opt => opt.MapFrom(p => p.Items.FirstOrDefault().User.Student.Classroom.Name))
            .ForMember(dest => dest.BranchName, opt => opt.MapFrom(p => p.Items.FirstOrDefault().User.Student.Branch.Name))
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
