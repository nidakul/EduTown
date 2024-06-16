using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserLessonConfiguration : IEntityTypeConfiguration<UserLesson>
{
    public void Configure(EntityTypeBuilder<UserLesson> builder)
    {
        builder.ToTable("UserLessons").HasKey(ul => ul.Id);

        builder.Property(ul => ul.Id).HasColumnName("Id").IsRequired();
        builder.Property(ul => ul.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(ul => ul.LessonId).HasColumnName("LessonId").IsRequired();
        builder.Property(ul => ul.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ul => ul.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ul => ul.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ul => !ul.DeletedDate.HasValue);
    }
}