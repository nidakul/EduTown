using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SchoolClassLessonConfiguration : IEntityTypeConfiguration<SchoolClassLesson>
{
    public void Configure(EntityTypeBuilder<SchoolClassLesson> builder)
    {
        builder.ToTable("SchoolClassLessons").HasKey(scl => scl.Id);

        builder.Property(scl => scl.Id).HasColumnName("Id").IsRequired();
        builder.Property(scl => scl.SchoolId).HasColumnName("SchoolId").IsRequired();
        builder.Property(scl => scl.ClassroomId).HasColumnName("ClassroomId").IsRequired();
        builder.Property(scl => scl.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(scl => scl.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(scl => scl.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(scl => !scl.DeletedDate.HasValue);
    }
}