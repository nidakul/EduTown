using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ExamDateConfiguration : IEntityTypeConfiguration<ExamDate>
{
    public void Configure(EntityTypeBuilder<ExamDate> builder)
    {
        builder.ToTable("ExamDates").HasKey(ed => ed.Id);

        builder.Property(ed => ed.Id).HasColumnName("Id").IsRequired();
        builder.Property(ed => ed.ExamType).HasColumnName("ExamType").IsRequired();
        builder.Property(ed => ed.StartDate).HasColumnName("StartDate").IsRequired();
        builder.Property(ed => ed.EndDate).HasColumnName("EndDate").IsRequired();
        builder.Property(ed => ed.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ed => ed.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ed => ed.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ed => !ed.DeletedDate.HasValue);
    }
}