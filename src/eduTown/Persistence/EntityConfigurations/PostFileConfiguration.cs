using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PostFileConfiguration : IEntityTypeConfiguration<PostFile>
{
    public void Configure(EntityTypeBuilder<PostFile> builder)
    {
        builder.ToTable("PostFiles").HasKey(pf => pf.Id);

        builder.Property(pf => pf.Id).HasColumnName("Id").IsRequired();
        builder.Property(pf => pf.PostId).HasColumnName("PostId").IsRequired();
        builder.Property(pf => pf.FilePath).HasColumnName("FilePath").IsRequired();
        builder.Property(pf => pf.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pf => pf.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pf => pf.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pf => !pf.DeletedDate.HasValue);
    }
}