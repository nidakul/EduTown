using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class GradeTypeConfiguration : IEntityTypeConfiguration<GradeType>
{
    public void Configure(EntityTypeBuilder<GradeType> builder)
    {
        builder.ToTable("GradeTypes").HasKey(gt => gt.Id);

        builder.Property(gt => gt.Id).HasColumnName("Id").IsRequired();
        builder.Property(gt => gt.Name).HasColumnName("Name").IsRequired();
        builder.Property(gt => gt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(gt => gt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(gt => gt.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(gt => !gt.DeletedDate.HasValue);
    }
}