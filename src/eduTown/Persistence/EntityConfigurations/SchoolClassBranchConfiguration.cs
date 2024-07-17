using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SchoolClassBranchConfiguration : IEntityTypeConfiguration<SchoolClassBranch>
{
    public void Configure(EntityTypeBuilder<SchoolClassBranch> builder)
    {
        builder.ToTable("SchoolClassBranches").HasKey(scb => scb.Id);

        builder.Property(scb => scb.Id).HasColumnName("Id").IsRequired();
        builder.Property(scb => scb.SchoolClassId).HasColumnName("SchoolClassId").IsRequired();
        builder.Property(scb => scb.BranchId).HasColumnName("BranchId").IsRequired();
        builder.Property(scb => scb.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(scb => scb.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(scb => scb.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(scb => !scb.DeletedDate.HasValue);
    }
}