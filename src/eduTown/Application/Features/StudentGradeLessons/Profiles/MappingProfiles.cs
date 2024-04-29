using Application.Features.StudentGradeLessons.Commands.Create;
using Application.Features.StudentGradeLessons.Commands.Delete;
using Application.Features.StudentGradeLessons.Commands.Update;
using Application.Features.StudentGradeLessons.Queries.GetById;
using Application.Features.StudentGradeLessons.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.StudentGradeLessons.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateStudentGradeLessonCommand, StudentGradeLesson>();
        CreateMap<StudentGradeLesson, CreatedStudentGradeLessonResponse>();

        CreateMap<UpdateStudentGradeLessonCommand, StudentGradeLesson>();
        CreateMap<StudentGradeLesson, UpdatedStudentGradeLessonResponse>();

        CreateMap<DeleteStudentGradeLessonCommand, StudentGradeLesson>();
        CreateMap<StudentGradeLesson, DeletedStudentGradeLessonResponse>();

        CreateMap<StudentGradeLesson, GetByIdStudentGradeLessonResponse>();

        CreateMap<StudentGradeLesson, GetListStudentGradeLessonListItemDto>();
        CreateMap<IPaginate<StudentGradeLesson>, GetListResponse<GetListStudentGradeLessonListItemDto>>();
    }
}