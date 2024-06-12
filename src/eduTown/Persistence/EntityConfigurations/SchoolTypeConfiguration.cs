using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SchoolTypeConfiguration : IEntityTypeConfiguration<SchoolType>
{
    public void Configure(EntityTypeBuilder<SchoolType> builder)
    {
        builder.ToTable("SchoolTypes").HasKey(st => st.Id);

        builder.Property(st => st.Id).HasColumnName("Id").IsRequired();
        builder.Property(st => st.Name).HasColumnName("Name").IsRequired();
        builder.Property(st => st.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(st => st.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(st => st.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(st => !st.DeletedDate.HasValue);
    }
}