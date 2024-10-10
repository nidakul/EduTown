using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PostCommentTaggedUserConfiguration : IEntityTypeConfiguration<PostCommentTaggedUser>
{
    public void Configure(EntityTypeBuilder<PostCommentTaggedUser> builder)
    {
        builder.ToTable("PostCommentTaggedUsers").HasKey(pctu => pctu.Id);

        builder.Property(pctu => pctu.Id).HasColumnName("Id").IsRequired();
        builder.Property(pctu => pctu.PostCommentId).HasColumnName("PostCommentId").IsRequired();
        builder.Property(pctu => pctu.TaggedUserId).HasColumnName("TaggedUserId").IsRequired();
        builder.Property(pctu => pctu.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pctu => pctu.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pctu => pctu.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pctu => !pctu.DeletedDate.HasValue);
    }
}