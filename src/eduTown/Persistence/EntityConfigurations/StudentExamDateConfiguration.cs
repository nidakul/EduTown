using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StudentExamDateConfiguration : IEntityTypeConfiguration<StudentExamDate>
{
    public void Configure(EntityTypeBuilder<StudentExamDate> builder)
    {
        builder.ToTable("StudentExamDates").HasKey(sed => sed.Id);

        builder.Property(sed => sed.Id).HasColumnName("Id").IsRequired();
        builder.Property(sed => sed.StudentId).HasColumnName("StudentId").IsRequired();
        builder.Property(sed => sed.ExamDateId).HasColumnName("ExamDateId").IsRequired();
        builder.Property(sed => sed.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sed => sed.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sed => sed.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(sed => !sed.DeletedDate.HasValue);
    }
}