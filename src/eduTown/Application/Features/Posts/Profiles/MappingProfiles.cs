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
            //.ForMember(dest => dest.CommentId, opt=> opt.MapFrom(p => p.PostComments.Select(p => p.Id).ToList()))
            .ForMember(dest => dest.Commenters, opt => opt.MapFrom(p => p.PostComments
            .OrderByDescending(dest => dest.CreatedDate)
            //.ForMember(dest => dest.ParentCommentId, opt=> opt.MapFrom(p => p.PostComments.Select(p => p.ParentCommentId)))
            .Select(pc => new CommenterDto
            {
                CommentId = pc.Id,
                CommenterUserId = pc.User.Id,
                CommenterImageUrl = pc.User.ImageUrl,
                CommenterFirstName = pc.User.FirstName,
                CommenterLastName = pc.User.LastName,
                Comment = pc.Comment,
                CommentCreatedDate = pc.CreatedDate,
                //TaggedUsers = pc.TaggedUsers.Select(tu => new TaggedUserResponse
                //{
                //    TaggedUserId = tu.User.Id,
                //    TaggedFirstName = tu.User.FirstName,  // Burada ilgili kullanıcıdan FirstName alınacak
                //    TaggedLastName = tu.User.LastName,  // Burada ilgili kullanıcıdan FirstName alınacak

                //}).ToList()
            }).ToList()
            ))
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



