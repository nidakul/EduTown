using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StudentGradeConfiguration : IEntityTypeConfiguration<StudentGrade>
{
    public void Configure(EntityTypeBuilder<StudentGrade> builder)
    {
        builder.ToTable("StudentGrades").HasKey(sg => sg.Id);

        builder.Property(sg => sg.Id).HasColumnName("Id").IsRequired();
        builder.Property(sg => sg.StudentId).HasColumnName("StudentId").IsRequired();
        builder.Property(sg => sg.GradeTypeId).HasColumnName("GradeTypeId").IsRequired();
        builder.Property(sg => sg.TermId).HasColumnName("TermId").IsRequired();
        builder.Property(sg => sg.LessonId).HasColumnName("LessonId").IsRequired();
        builder.Property(sg => sg.ExamCount).HasColumnName("ExamCount").IsRequired();
        builder.Property(sg => sg.Grade).HasColumnName("Grade").IsRequired();
        builder.Property(sg => sg.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sg => sg.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sg => sg.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(sg => !sg.DeletedDate.HasValue);
    }
}
