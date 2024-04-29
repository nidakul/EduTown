using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StudentGradeLessonConfiguration : IEntityTypeConfiguration<StudentGradeLesson>
{
    public void Configure(EntityTypeBuilder<StudentGradeLesson> builder)
    {
        builder.ToTable("StudentGradeLessons").HasKey(sgl => sgl.Id);

        builder.Property(sgl => sgl.Id).HasColumnName("Id").IsRequired();
        builder.Property(sgl => sgl.StudentGradeId).HasColumnName("StudentGradeId").IsRequired();
        builder.Property(sgl => sgl.LessonId).HasColumnName("LessonId").IsRequired();
        builder.Property(sgl => sgl.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sgl => sgl.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sgl => sgl.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(sgl => !sgl.DeletedDate.HasValue);
    }
}