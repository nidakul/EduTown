using System.Reflection;
using Application.Services.AuthenticatorService;
using Application.Services.AuthService;
using Application.Services.UsersService;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using NArchitecture.Core.Application.Pipelines.Validation;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Abstraction;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Configurations;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Serilog.File;
using NArchitecture.Core.ElasticSearch;
using NArchitecture.Core.ElasticSearch.Models;
using NArchitecture.Core.Localization.Resource.Yaml.DependencyInjection;
using NArchitecture.Core.Mailing;
using NArchitecture.Core.Mailing.MailKit;
using NArchitecture.Core.Security.DependencyInjection;
using NArchitecture.Core.Security.JWT;
using Application.Services.Instructors;
using Application.Services.Students;
using Application.Services.Schools;
using Application.Services.Classrooms;
using Application.Services.UserCertificates;
using Application.Services.Certificates;
using Application.Services.Lessons;
using Application.Services.StudentGradeLessons;
using Application.Services.GradeTypes;
using Application.Services.StudentGrades;
using Application.Services.Cities;
using Application.Services.SchoolTypes;
using Application.Services.InstructorDepartments;
using Application.Services.Departments;
using Application.Services.ExamDates;
using Application.Services.LessonExamDates;
using Application.Services.StudentExamDates;
using Application.Services.SchoolLessons;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        MailSettings mailSettings,
        FileLogConfiguration fileLogConfiguration,
        ElasticSearchConfig elasticSearchConfig,
        TokenOptions tokenOptions
    )
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddSingleton<IMailService, MailKitMailService>(_ => new MailKitMailService(mailSettings));
        services.AddSingleton<ILogger, SerilogFileLogger>(_ => new SerilogFileLogger(fileLogConfiguration));
        services.AddSingleton<IElasticSearch, ElasticSearchManager>(_ => new ElasticSearchManager(elasticSearchConfig));

        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IAuthenticatorService, AuthenticatorManager>();
        services.AddScoped<IUserService, UserManager>();

        services.AddYamlResourceLocalization();

        services.AddSecurityServices<Guid, int, Guid>(tokenOptions);

        services.AddScoped<IInstructorService, InstructorManager>();
        services.AddScoped<IStudentService, StudentManager>();
        services.AddScoped<ISchoolService, SchoolManager>();
        services.AddScoped<IClassroomService, ClassroomManager>();
        services.AddScoped<IUserCertificateService, UserCertificateManager>();
        services.AddScoped<ICertificateService, CertificateManager>();
        services.AddScoped<ILessonService, LessonManager>();
        services.AddScoped<IStudentGradeLessonService, StudentGradeLessonManager>();
        services.AddScoped<IGradeTypeService, GradeTypeManager>();
        services.AddScoped<IStudentGradeService, StudentGradeManager>();
        services.AddScoped<ICityService, CityManager>();
        services.AddScoped<ISchoolService, SchoolManager>();
        services.AddScoped<IClassroomService, ClassroomManager>();
        services.AddScoped<ILessonService, LessonManager>();
        services.AddScoped<ISchoolService, SchoolManager>();
        services.AddScoped<ISchoolTypeService, SchoolTypeManager>();
        services.AddScoped<IInstructorDepartmentService, InstructorDepartmentManager>();
        services.AddScoped<IDepartmentService, DepartmentManager>();
        services.AddScoped<IExamDateService, ExamDateManager>();
        services.AddScoped<ILessonExamDateService, LessonExamDateManager>();
        services.AddScoped<IStudentExamDateService, StudentExamDateManager>();
        services.AddScoped<ISchoolLessonService, SchoolLessonManager>();
        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type? item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}
