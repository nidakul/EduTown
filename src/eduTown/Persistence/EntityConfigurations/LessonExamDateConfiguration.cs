using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LessonExamDateConfiguration : IEntityTypeConfiguration<LessonExamDate>
{
    public void Configure(EntityTypeBuilder<LessonExamDate> builder)
    {
        builder.ToTable("LessonExamDates").HasKey(led => led.Id);

        builder.Property(led => led.Id).HasColumnName("Id").IsRequired();
        builder.Property(led => led.LessonId).HasColumnName("LessonId").IsRequired();
        builder.Property(led => led.ExamDateId).HasColumnName("ExamDateId").IsRequired();
        builder.Property(led => led.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(led => led.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(led => led.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(led => !led.DeletedDate.HasValue);
    }
}