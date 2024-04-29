using Application.Features.StudentGrades.Commands.Create;
using Application.Features.StudentGrades.Commands.Delete;
using Application.Features.StudentGrades.Commands.Update;
using Application.Features.StudentGrades.Queries.GetById;
using Application.Features.StudentGrades.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.StudentGrades.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateStudentGradeCommand, StudentGrade>();
        CreateMap<StudentGrade, CreatedStudentGradeResponse>();

        CreateMap<UpdateStudentGradeCommand, StudentGrade>();
        CreateMap<StudentGrade, UpdatedStudentGradeResponse>();

        CreateMap<DeleteStudentGradeCommand, StudentGrade>();
        CreateMap<StudentGrade, DeletedStudentGradeResponse>();

        CreateMap<StudentGrade, GetByIdStudentGradeResponse>();

        CreateMap<StudentGrade, GetListStudentGradeListItemDto>();
        CreateMap<IPaginate<StudentGrade>, GetListResponse<GetListStudentGradeListItemDto>>();
    }
}