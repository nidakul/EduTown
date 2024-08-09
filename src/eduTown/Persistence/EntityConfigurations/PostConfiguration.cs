using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(p => p.SchoolId).HasColumnName("SchoolId").IsRequired();
        builder.Property(p => p.ClassroomId).HasColumnName("ClassroomId").IsRequired();
        builder.Property(p => p.BranchId).HasColumnName("BranchId").IsRequired();
        builder.Property(p => p.LikeCount).HasColumnName("LikeCount").IsRequired();
        builder.Property(p => p.Message).HasColumnName("Message").IsRequired();
        builder.Property(p => p.IsCommentable).HasColumnName("IsCommentable").IsRequired();
        builder.Property(p => p.FilePath).HasColumnName("FilePath");
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
    }
}


