namespace Domain.Entities;

public class User : NArchitecture.Core.Security.Entities.User<Guid>
{
    public int CountryId { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public string NationalIdentity { get; set; }
    public int StudentNo { get; set; }
    public string ImageUrl { get; set; }
    public string SchoolName { get; set; }

    public virtual Country Country { get; set; } 
    public virtual City City { get; set; }
    public virtual District District { get; set; }

    public virtual ICollection<UserGrade> UserGrades { get; set; }
    public virtual ICollection<UserInstructor> UserInstructors { get; set; }
    public virtual ICollection<UserSchool> UserSchools { get; set; }
    public virtual ICollection<UserExam> UserExams { get; set; }
    public virtual ICollection<UserClass> UserClasses { get; set; }

    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = default!;
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = default!;
    public virtual ICollection<OtpAuthenticator> OtpAuthenticators { get; set; } = default!;
    public virtual ICollection<EmailAuthenticator> EmailAuthenticators { get; set; } = default!;
}







