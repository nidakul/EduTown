using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Persistence.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer("BaseDb"));
        services.AddDbMigrationApplier(buildServices => buildServices.GetRequiredService<BaseDbContext>());

        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

        services.AddScoped<IInstructorRepository, InstructorRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<ISchoolRepository, SchoolRepository>();
        services.AddScoped<IClassroomRepository, ClassroomRepository>();
        services.AddScoped<IUserCertificateRepository, UserCertificateRepository>();
        services.AddScoped<ICertificateRepository, CertificateRepository>();
        services.AddScoped<ILessonRepository, LessonRepository>();
        services.AddScoped<IGradeTypeRepository, GradeTypeRepository>();
        services.AddScoped<IStudentGradeRepository, StudentGradeRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<ISchoolRepository, SchoolRepository>();
        services.AddScoped<IClassroomRepository, ClassroomRepository>();
        services.AddScoped<ILessonRepository, LessonRepository>();
        services.AddScoped<ISchoolRepository, SchoolRepository>();
        services.AddScoped<ISchoolTypeRepository, SchoolTypeRepository>();
        services.AddScoped<IInstructorDepartmentRepository, InstructorDepartmentRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IExamDateRepository, ExamDateRepository>();
        services.AddScoped<ILessonExamDateRepository, LessonExamDateRepository>();
        services.AddScoped<IStudentExamDateRepository, StudentExamDateRepository>();
        services.AddScoped<ISchoolClassRepository, SchoolClassRepository>();
        services.AddScoped<ISchoolClassLessonRepository, SchoolClassLessonRepository>();
        services.AddScoped<ITermRepository, TermRepository>();
        return services;
    }
}
