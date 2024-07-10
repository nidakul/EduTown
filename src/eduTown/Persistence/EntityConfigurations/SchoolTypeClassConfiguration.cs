using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SchoolTypeClassConfiguration : IEntityTypeConfiguration<SchoolTypeClass>
{
    public void Configure(EntityTypeBuilder<SchoolTypeClass> builder)
    {
        builder.ToTable("SchoolTypeClasses").HasKey(stc => stc.Id);

        builder.Property(stc => stc.Id).HasColumnName("Id").IsRequired();
        builder.Property(stc => stc.SchoolTypeId).HasColumnName("SchoolTypeId").IsRequired();
        builder.Property(stc => stc.ClassroomId).HasColumnName("ClassroomId").IsRequired();
        builder.Property(stc => stc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(stc => stc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(stc => stc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(stc => !stc.DeletedDate.HasValue);
    }
}