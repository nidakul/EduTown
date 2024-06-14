using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class InstructorDepartmentConfiguration : IEntityTypeConfiguration<InstructorDepartment>
{
    public void Configure(EntityTypeBuilder<InstructorDepartment> builder)
    {
        builder.ToTable("InstructorDepartments").HasKey(id => id.Id);

        builder.Property(id => id.Id).HasColumnName("Id").IsRequired();
        builder.Property(id => id.InstructorId).HasColumnName("InstructorId").IsRequired();
        builder.Property(id => id.DepartmentId).HasColumnName("DepartmentId").IsRequired();
        builder.Property(id => id.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(id => id.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(id => id.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(id => !id.DeletedDate.HasValue);
    }
}