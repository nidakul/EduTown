using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SchoolClassroomConfiguration : IEntityTypeConfiguration<SchoolClassroom>
{
    public void Configure(EntityTypeBuilder<SchoolClassroom> builder)
    {
        builder.ToTable("SchoolClassrooms").HasKey(sc => sc.Id);

        builder.Property(sc => sc.Id).HasColumnName("Id").IsRequired();
        builder.Property(sc => sc.SchoolId).HasColumnName("SchoolId").IsRequired();
        builder.Property(sc => sc.ClassroomId).HasColumnName("ClassroomId").IsRequired();
        builder.Property(sc => sc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sc => sc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sc => sc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(sc => !sc.DeletedDate.HasValue);
    }
}