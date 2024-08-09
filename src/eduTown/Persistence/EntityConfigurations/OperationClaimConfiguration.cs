using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Instructors.Constants;
using Application.Features.Students.Constants;
using Application.Features.Schools.Constants;
using Application.Features.Classrooms.Constants;
using Application.Features.UserCertificates.Constants;
using Application.Features.Certificates.Constants;
using Application.Features.Lessons.Constants;
using Application.Features.GradeTypes.Constants;
using Application.Features.StudentGrades.Constants;
using Application.Features.Cities.Constants;
using Application.Features.SchoolTypes.Constants;
using Application.Features.ExamDates.Constants;
using Application.Features.LessonExamDates.Constants;
using Application.Features.StudentExamDates.Constants;
using Application.Features.SchoolClasses.Constants;
using Application.Features.SchoolClassLessons.Constants;
using Application.Features.Terms.Constants;
using Application.Features.SchoolTypeClasses.Constants;
using Application.Features.Branches.Constants;
using Application.Features.SchoolClassBranches.Constants;
using Application.Features.Posts.Constants;
using Application.Features.PostInteractions.Constants;
using Application.Features.PostComments.Constants;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion



        #region Instructors CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = InstructorsOperationClaims.Admin },
                new() { Id = ++lastId, Name = InstructorsOperationClaims.Read },
                new() { Id = ++lastId, Name = InstructorsOperationClaims.Write },
                new() { Id = ++lastId, Name = InstructorsOperationClaims.Create },
                new() { Id = ++lastId, Name = InstructorsOperationClaims.Update },
                new() { Id = ++lastId, Name = InstructorsOperationClaims.Delete },
            ]
        );
        #endregion


        #region Students CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = StudentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Read },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Write },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Create },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Update },
                new() { Id = ++lastId, Name = StudentsOperationClaims.Delete },
            ]
        );
        #endregion


        #region Schools CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SchoolsOperationClaims.Admin },
                new() { Id = ++lastId, Name = SchoolsOperationClaims.Read },
                new() { Id = ++lastId, Name = SchoolsOperationClaims.Write },
                new() { Id = ++lastId, Name = SchoolsOperationClaims.Create },
                new() { Id = ++lastId, Name = SchoolsOperationClaims.Update },
                new() { Id = ++lastId, Name = SchoolsOperationClaims.Delete },
            ]
        );
        #endregion


        #region Classrooms CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ClassroomsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ClassroomsOperationClaims.Read },
                new() { Id = ++lastId, Name = ClassroomsOperationClaims.Write },
                new() { Id = ++lastId, Name = ClassroomsOperationClaims.Create },
                new() { Id = ++lastId, Name = ClassroomsOperationClaims.Update },
                new() { Id = ++lastId, Name = ClassroomsOperationClaims.Delete },
            ]
        );
        #endregion


        #region UserCertificates CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserCertificatesOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserCertificatesOperationClaims.Read },
                new() { Id = ++lastId, Name = UserCertificatesOperationClaims.Write },
                new() { Id = ++lastId, Name = UserCertificatesOperationClaims.Create },
                new() { Id = ++lastId, Name = UserCertificatesOperationClaims.Update },
                new() { Id = ++lastId, Name = UserCertificatesOperationClaims.Delete },
            ]
        );
        #endregion


        #region Certificates CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CertificatesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CertificatesOperationClaims.Read },
                new() { Id = ++lastId, Name = CertificatesOperationClaims.Write },
                new() { Id = ++lastId, Name = CertificatesOperationClaims.Create },
                new() { Id = ++lastId, Name = CertificatesOperationClaims.Update },
                new() { Id = ++lastId, Name = CertificatesOperationClaims.Delete },
            ]
        );
        #endregion


        #region Lessons CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LessonsOperationClaims.Admin },
                new() { Id = ++lastId, Name = LessonsOperationClaims.Read },
                new() { Id = ++lastId, Name = LessonsOperationClaims.Write },
                new() { Id = ++lastId, Name = LessonsOperationClaims.Create },
                new() { Id = ++lastId, Name = LessonsOperationClaims.Update },
                new() { Id = ++lastId, Name = LessonsOperationClaims.Delete },
            ]
        );
        #endregion


        #region GradeTypes CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = GradeTypesOperationClaims.Admin },
                new() { Id = ++lastId, Name = GradeTypesOperationClaims.Read },
                new() { Id = ++lastId, Name = GradeTypesOperationClaims.Write },
                new() { Id = ++lastId, Name = GradeTypesOperationClaims.Create },
                new() { Id = ++lastId, Name = GradeTypesOperationClaims.Update },
                new() { Id = ++lastId, Name = GradeTypesOperationClaims.Delete },
            ]
        );
        #endregion


        #region StudentGrades CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = StudentGradesOperationClaims.Admin },
                new() { Id = ++lastId, Name = StudentGradesOperationClaims.Read },
                new() { Id = ++lastId, Name = StudentGradesOperationClaims.Write },
                new() { Id = ++lastId, Name = StudentGradesOperationClaims.Create },
                new() { Id = ++lastId, Name = StudentGradesOperationClaims.Update },
                new() { Id = ++lastId, Name = StudentGradesOperationClaims.Delete },
            ]
        );
        #endregion


        #region Cities CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CitiesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Read },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Write },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Create },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Update },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Delete },
            ]
        );
        #endregion


        #region Schools CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SchoolsOperationClaims.Admin },
                new() { Id = ++lastId, Name = SchoolsOperationClaims.Read },
                new() { Id = ++lastId, Name = SchoolsOperationClaims.Write },
                new() { Id = ++lastId, Name = SchoolsOperationClaims.Create },
                new() { Id = ++lastId, Name = SchoolsOperationClaims.Update },
                new() { Id = ++lastId, Name = SchoolsOperationClaims.Delete },
            ]
        );
        #endregion



        #region Classrooms CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ClassroomsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ClassroomsOperationClaims.Read },
                new() { Id = ++lastId, Name = ClassroomsOperationClaims.Write },
                new() { Id = ++lastId, Name = ClassroomsOperationClaims.Create },
                new() { Id = ++lastId, Name = ClassroomsOperationClaims.Update },
                new() { Id = ++lastId, Name = ClassroomsOperationClaims.Delete },
            ]
        );
        #endregion


        #region Lessons CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LessonsOperationClaims.Admin },
                new() { Id = ++lastId, Name = LessonsOperationClaims.Read },
                new() { Id = ++lastId, Name = LessonsOperationClaims.Write },
                new() { Id = ++lastId, Name = LessonsOperationClaims.Create },
                new() { Id = ++lastId, Name = LessonsOperationClaims.Update },
                new() { Id = ++lastId, Name = LessonsOperationClaims.Delete },
            ]
        );
        #endregion





        #region Schools CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SchoolsOperationClaims.Admin },
                new() { Id = ++lastId, Name = SchoolsOperationClaims.Read },
                new() { Id = ++lastId, Name = SchoolsOperationClaims.Write },
                new() { Id = ++lastId, Name = SchoolsOperationClaims.Create },
                new() { Id = ++lastId, Name = SchoolsOperationClaims.Update },
                new() { Id = ++lastId, Name = SchoolsOperationClaims.Delete },
            ]
        );
        #endregion





        #region SchoolTypes CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SchoolTypesOperationClaims.Admin },
                new() { Id = ++lastId, Name = SchoolTypesOperationClaims.Read },
                new() { Id = ++lastId, Name = SchoolTypesOperationClaims.Write },
                new() { Id = ++lastId, Name = SchoolTypesOperationClaims.Create },
                new() { Id = ++lastId, Name = SchoolTypesOperationClaims.Update },
                new() { Id = ++lastId, Name = SchoolTypesOperationClaims.Delete },
            ]
        );
        #endregion



        #region ExamDates CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ExamDatesOperationClaims.Admin },
                new() { Id = ++lastId, Name = ExamDatesOperationClaims.Read },
                new() { Id = ++lastId, Name = ExamDatesOperationClaims.Write },
                new() { Id = ++lastId, Name = ExamDatesOperationClaims.Create },
                new() { Id = ++lastId, Name = ExamDatesOperationClaims.Update },
                new() { Id = ++lastId, Name = ExamDatesOperationClaims.Delete },
            ]
        );
        #endregion


        #region LessonExamDates CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LessonExamDatesOperationClaims.Admin },
                new() { Id = ++lastId, Name = LessonExamDatesOperationClaims.Read },
                new() { Id = ++lastId, Name = LessonExamDatesOperationClaims.Write },
                new() { Id = ++lastId, Name = LessonExamDatesOperationClaims.Create },
                new() { Id = ++lastId, Name = LessonExamDatesOperationClaims.Update },
                new() { Id = ++lastId, Name = LessonExamDatesOperationClaims.Delete },
            ]
        );
        #endregion




        #region StudentExamDates CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = StudentExamDatesOperationClaims.Admin },
                new() { Id = ++lastId, Name = StudentExamDatesOperationClaims.Read },
                new() { Id = ++lastId, Name = StudentExamDatesOperationClaims.Write },
                new() { Id = ++lastId, Name = StudentExamDatesOperationClaims.Create },
                new() { Id = ++lastId, Name = StudentExamDatesOperationClaims.Update },
                new() { Id = ++lastId, Name = StudentExamDatesOperationClaims.Delete },
            ]
        );
        #endregion


        
        #region SchoolClasses CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SchoolClassesOperationClaims.Admin },
                new() { Id = ++lastId, Name = SchoolClassesOperationClaims.Read },
                new() { Id = ++lastId, Name = SchoolClassesOperationClaims.Write },
                new() { Id = ++lastId, Name = SchoolClassesOperationClaims.Create },
                new() { Id = ++lastId, Name = SchoolClassesOperationClaims.Update },
                new() { Id = ++lastId, Name = SchoolClassesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region SchoolClassLessons CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SchoolClassLessonsOperationClaims.Admin },
                new() { Id = ++lastId, Name = SchoolClassLessonsOperationClaims.Read },
                new() { Id = ++lastId, Name = SchoolClassLessonsOperationClaims.Write },
                new() { Id = ++lastId, Name = SchoolClassLessonsOperationClaims.Create },
                new() { Id = ++lastId, Name = SchoolClassLessonsOperationClaims.Update },
                new() { Id = ++lastId, Name = SchoolClassLessonsOperationClaims.Delete },
            ]
        );
        #endregion
        
                
        
        #region Terms CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = TermsOperationClaims.Admin },
                new() { Id = ++lastId, Name = TermsOperationClaims.Read },
                new() { Id = ++lastId, Name = TermsOperationClaims.Write },
                new() { Id = ++lastId, Name = TermsOperationClaims.Create },
                new() { Id = ++lastId, Name = TermsOperationClaims.Update },
                new() { Id = ++lastId, Name = TermsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region SchoolTypeClasses CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SchoolTypeClassesOperationClaims.Admin },
                new() { Id = ++lastId, Name = SchoolTypeClassesOperationClaims.Read },
                new() { Id = ++lastId, Name = SchoolTypeClassesOperationClaims.Write },
                new() { Id = ++lastId, Name = SchoolTypeClassesOperationClaims.Create },
                new() { Id = ++lastId, Name = SchoolTypeClassesOperationClaims.Update },
                new() { Id = ++lastId, Name = SchoolTypeClassesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Branches CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BranchesOperationClaims.Admin },
                new() { Id = ++lastId, Name = BranchesOperationClaims.Read },
                new() { Id = ++lastId, Name = BranchesOperationClaims.Write },
                new() { Id = ++lastId, Name = BranchesOperationClaims.Create },
                new() { Id = ++lastId, Name = BranchesOperationClaims.Update },
                new() { Id = ++lastId, Name = BranchesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region SchoolClassBranches CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SchoolClassBranchesOperationClaims.Admin },
                new() { Id = ++lastId, Name = SchoolClassBranchesOperationClaims.Read },
                new() { Id = ++lastId, Name = SchoolClassBranchesOperationClaims.Write },
                new() { Id = ++lastId, Name = SchoolClassBranchesOperationClaims.Create },
                new() { Id = ++lastId, Name = SchoolClassBranchesOperationClaims.Update },
                new() { Id = ++lastId, Name = SchoolClassBranchesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Posts CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PostsOperationClaims.Admin },
                new() { Id = ++lastId, Name = PostsOperationClaims.Read },
                new() { Id = ++lastId, Name = PostsOperationClaims.Write },
                new() { Id = ++lastId, Name = PostsOperationClaims.Create },
                new() { Id = ++lastId, Name = PostsOperationClaims.Update },
                new() { Id = ++lastId, Name = PostsOperationClaims.Delete },
            ]
        );
        #endregion
        
               
                        
        
        #region PostInteractions CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PostInteractionsOperationClaims.Admin },
                new() { Id = ++lastId, Name = PostInteractionsOperationClaims.Read },
                new() { Id = ++lastId, Name = PostInteractionsOperationClaims.Write },
                new() { Id = ++lastId, Name = PostInteractionsOperationClaims.Create },
                new() { Id = ++lastId, Name = PostInteractionsOperationClaims.Update },
                new() { Id = ++lastId, Name = PostInteractionsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region PostComments CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PostCommentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = PostCommentsOperationClaims.Read },
                new() { Id = ++lastId, Name = PostCommentsOperationClaims.Write },
                new() { Id = ++lastId, Name = PostCommentsOperationClaims.Create },
                new() { Id = ++lastId, Name = PostCommentsOperationClaims.Update },
                new() { Id = ++lastId, Name = PostCommentsOperationClaims.Delete },
            ]
        );
        #endregion
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
