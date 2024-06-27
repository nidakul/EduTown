using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using OtpNet;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class StudentGradeRepository : EfRepositoryBase<StudentGrade, int, BaseDbContext>, IStudentGradeRepository
{
    public StudentGradeRepository(BaseDbContext context) : base(context)
    {
    }

    //public List<StudentGrade> GetStudentGradesByUserId(Guid userId)
    //{
    //    var studentGrades = Context.StudentGrades
    //                               .Where(sg => sg.UserId == userId)
    //                               .GroupBy(sg => sg.Classroom.Name) // Classroom'a göre gruplama
    //                               .Select(groupByClassroom => new
    //                               {
    //                                   ClassroomName = groupByClassroom.Key,
    //                                   Lessons = groupByClassroom.GroupBy(sg => sg.Lesson.Name) // Lesson'a göre gruplama
    //                                                          .Select(groupByLesson => new
    //                                                          {
    //                                                              LessonName = groupByLesson.Key,
    //                                                              Grades = groupByLesson.ToList()
    //                                                          })
    //                                                          .ToList()
    //                               })
    //                               .ToList();  

    //    // Burada studentGrades'i dönüştürerek veya başka bir işlem yaparak geri dönebilirsiniz
    //    // Örneğin DTO'ya dönüştürme işlemleri yapabilirsiniz.

    //    return studentGrades; 
    //}
}


//CreateMap<User, GetStudentGradesByUserIdResponse>()
//      .ForMember(u => u.Id, opt => opt.MapFrom(u => u.Id))
//      .ForMember(dest => dest.StudentGrades, opt => opt.MapFrom(

//          src => src.StudentGrades.GroupBy(sg => sg.Classroom.Name),
//          src => src.StudentGrades.GroupBy(sg => sg.Lesson.Name)
//              .Select(g => new StudentGradesByClassroomDto
//              {
//                  //ClassroomName = g.Key, 
//                  Lessons = g.GroupBy(cl => cl.Lesson.Name)
//          .Select(g => new StudentGradesByLessonDto
//          {
//              LessonName = g.Key,
//              Grades = g.OrderBy(ec => ec.ExamCount)
//                  .GroupBy(grade => grade.GradeType.Name)
//                            .Select(grp => new StudentGradeDetailsDto
//                            {
//                                GradeTypeName = grp.Key,
//                                GradesDto = grp.Select(g => new GradeDto
//                                {
//                                    ExamCount = g.ExamCount,
//                                    Grade = g.Grade
//                                }).ToList()
//                            }).ToList()
//          }).ToList()
//              }).ToList()
//      ))
//      .ReverseMap();