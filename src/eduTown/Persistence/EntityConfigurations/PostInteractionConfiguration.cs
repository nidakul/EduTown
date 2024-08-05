using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PostInteractionConfiguration : IEntityTypeConfiguration<PostInteraction>
{
    public void Configure(EntityTypeBuilder<PostInteraction> builder)
    {
        builder.ToTable("PostInteractions").HasKey(pi => pi.Id);

        builder.Property(pi => pi.Id).HasColumnName("Id").IsRequired();
        builder.Property(pi => pi.PostId).HasColumnName("PostId").IsRequired();
        builder.Property(pi => pi.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(pi => pi.Comment).HasColumnName("Comment").IsRequired();
        builder.Property(pi => pi.IsFavorite).HasColumnName("IsFavorite").IsRequired();
        builder.Property(pi => pi.IsLiked).HasColumnName("IsLiked").IsRequired();
        builder.Property(pi => pi.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pi => pi.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pi => pi.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pi => !pi.DeletedDate.HasValue);
    }
}