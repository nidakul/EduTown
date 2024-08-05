using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<School> Schools { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<UserCertificate> UserCertificates { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<GradeType> GradeTypes { get; set; }
    public DbSet<StudentGrade> StudentGrades { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<SchoolType> SchoolTypes { get; set; }
    public DbSet<ExamDate> ExamDates { get; set; }
    public DbSet<LessonExamDate> LessonExamDates { get; set; }
    public DbSet<StudentExamDate> StudentExamDates { get; set; }
    public DbSet<SchoolClass> SchoolClasses { get; set; }
    public DbSet<SchoolClassLesson> SchoolClassLessons { get; set; }
    public DbSet<Term> Terms { get; set; }
    public DbSet<SchoolTypeClass> SchoolTypeClasses { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<SchoolClassBranch> SchoolClassBranches { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostInteraction> PostInteractions { get; set; }

    public BaseDbContext() 
    { 

    }

    public BaseDbContext(DbContextOptions<BaseDbContext> dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    //}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = localhost; Database = EduTown; User Id = SA; Password = rentacardb; TrustServerCertificate=true");                       
        
        
        

    }
}



