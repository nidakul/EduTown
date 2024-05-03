using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LessonClassroomConfiguration : IEntityTypeConfiguration<LessonClassroom>
{
    public void Configure(EntityTypeBuilder<LessonClassroom> builder)
    {
        builder.ToTable("LessonClassrooms").HasKey(lc => lc.Id);

        builder.Property(lc => lc.Id).HasColumnName("Id").IsRequired();
        builder.Property(lc => lc.LessonId).HasColumnName("LessonId").IsRequired();
        builder.Property(lc => lc.ClassroomId).HasColumnName("ClassroomId").IsRequired();
        builder.Property(lc => lc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(lc => lc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(lc => lc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(lc => !lc.DeletedDate.HasValue);
    }
}