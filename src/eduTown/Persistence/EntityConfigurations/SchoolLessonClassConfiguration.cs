using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SchoolLessonClassConfiguration : IEntityTypeConfiguration<SchoolLessonClass>
{
    public void Configure(EntityTypeBuilder<SchoolLessonClass> builder)
    {
        builder.ToTable("SchoolLessonClasses").HasKey(slc => slc.Id);

        builder.Property(slc => slc.Id).HasColumnName("Id").IsRequired();
        builder.Property(slc => slc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(slc => slc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(slc => slc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(slc => !slc.DeletedDate.HasValue);
    }
}