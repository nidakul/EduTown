﻿namespace Domain.Entities;

public class User : NArchitecture.Core.Security.Entities.User<Guid>
{
    public int SchoolId { get; set; }
    public string NationalIdentity { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? ImageUrl { get; set; } 
    //Kayıt Tarihi createdDate'den al

    public virtual Student Student { get; set; }
    public virtual Instructor Instructor { get; set; }
    public virtual School School { get; set; }

    public virtual ICollection<UserClassroom>? UserClassrooms { get; set; }
    public virtual ICollection<UserCertificate>? UserCertificates { get; set; }
    public virtual ICollection<StudentGrade>? StudentGrades { get; set; }

    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = default!;
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = default!;
    public virtual ICollection<OtpAuthenticator> OtpAuthenticators { get; set; } = default!;
    public virtual ICollection<EmailAuthenticator> EmailAuthenticators { get; set; } = default!;

    public User()
    {
    }
}






