using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SchoolLessonConfiguration : IEntityTypeConfiguration<SchoolLesson>
{
    public void Configure(EntityTypeBuilder<SchoolLesson> builder)
    {
        builder.ToTable("SchoolLessons").HasKey(sl => sl.Id);

        builder.Property(sl => sl.Id).HasColumnName("Id").IsRequired();
        builder.Property(sl => sl.SchoolId).HasColumnName("SchoolId").IsRequired();
        builder.Property(sl => sl.LessonId).HasColumnName("LessonId").IsRequired();
        builder.Property(sl => sl.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sl => sl.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sl => sl.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(sl => !sl.DeletedDate.HasValue);
    }
}