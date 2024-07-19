using Application.Features.Students.Commands.Create;
using Application.Features.Students.Commands.Delete;
using Application.Features.Students.Commands.Update;
using Application.Features.Students.Queries.GetById;
using Application.Features.Students.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Students.Queries.GetStudentDetail;
using Application.Features.Students.Queries.GetStudentGradesByStudentId;

namespace Application.Features.Students.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateStudentCommand, Student>();
        CreateMap<Student, CreatedStudentResponse>();

        CreateMap<UpdateStudentCommand, Student>();
        CreateMap<Student, UpdatedStudentResponse>();

        CreateMap<DeleteStudentCommand, Student>();
        CreateMap<Student, DeletedStudentResponse>();

        CreateMap<Student, GetByIdStudentResponse>();

        CreateMap<Student, GetListStudentListItemDto>();
        CreateMap<IPaginate<Student>, GetListResponse<GetListStudentListItemDto>>();

        CreateMap<IPaginate<Student>, GetListResponse<GetListStudentDetailResponse>>();
        CreateMap<Student, GetListStudentDetailResponse>()
            .ForMember(s => s.SchoolId, opt => opt.MapFrom(s => s.User.School.Id))
            .ForMember(s => s.ClassroomId, opt => opt.MapFrom(s => s.Classroom.Id))
            .ForMember(s => s.BranchId, opt => opt.MapFrom(s => s.Branch.Id))
            .ForMember(s => s.SchoolName, opt => opt.MapFrom(s => s.User.School.Name))
            .ForMember(s => s.BranchName, opt => opt.MapFrom(s => s.Branch.Name))
            .ForMember(s => s.NationalIdentity, opt => opt.MapFrom(s => s.User.NationalIdentity))
            .ForMember(s => s.FirstName, opt => opt.MapFrom(s => s.User.FirstName))
            .ForMember(s => s.LastName, opt => opt.MapFrom(s => s.User.LastName))
            .ForMember(s => s.Email, opt => opt.MapFrom(s => s.User.Email))
            .ForMember(s => s.ImageUrl, opt => opt.MapFrom(s => s.User.ImageUrl))
            .ForMember(s => s.Gender, opt => opt.MapFrom(s => s.User.Gender))
            .ForMember(s => s.ClassroomName, opt => opt.MapFrom(s => s.Classroom.Name))
            .ReverseMap();

        CreateMap<Student, GetStudentGradesByStudentIdResponse>()
     .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
     .ForMember(dest => dest.StudentGrades, opt => opt.MapFrom(src => src.StudentGrades
         .GroupBy(sg => new { sg.Student.Classroom.Id, sg.Student.Classroom.Name })
         .Select(g => new StudentGradesByClassroomDto
         {
             ClassroomId = g.Key.Id,
             ClassroomName = g.Key.Name,
             TermNames = g.GroupBy(cl => new { cl.Term.Id, cl.Term.Name })
                 .Select(gl => new StudentGradesByTermDto
                 {
                     TermId = gl.Key.Id,
                     TermName = gl.Key.Name,
                     Lessons = gl.GroupBy(lesson => new { lesson.Lesson.Id, lesson.Lesson.Name })
                         .Select(lessonGroup => new StudentGradesByLessonDto
                         {
                             LessonId = lessonGroup.Key.Id,
                             LessonName = lessonGroup.Key.Name,
                             Grades = lessonGroup.GroupBy(grade => new { grade.GradeType.Id, grade.GradeType.Name })
                                 .Select(gradeGroup => new StudentGradeDetailsDto
                                 {
                                     GradeTypeId = gradeGroup.Key.Id,
                                     GradeTypeName = gradeGroup.Key.Name,
                                     GradesDto = gradeGroup.Select(gr => new GradeDto
                                     {
                                         ExamCount = gr.ExamCount,
                                         Grade = gr.Grade
                                     })
                                     .OrderBy(gd => gd.ExamCount)
                                     .ToList()
                                 }).ToList()
                         }).ToList()
                 }).ToList()
         }).ToList()
     ))
     .ReverseMap();


    }
}