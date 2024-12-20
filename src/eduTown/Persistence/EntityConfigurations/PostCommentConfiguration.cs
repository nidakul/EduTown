using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PostCommentConfiguration : IEntityTypeConfiguration<PostComment>
{
    public void Configure(EntityTypeBuilder<PostComment> builder)
    {
        builder.ToTable("PostComments").HasKey(pc => pc.Id);

        builder.Property(pc => pc.Id).HasColumnName("Id").IsRequired();
        builder.Property(pc => pc.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(pc => pc.PostId).HasColumnName("PostId").IsRequired();
        builder.Property(pc => pc.Comment).HasColumnName("Comment").IsRequired();
        builder.Property(pc => pc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pc => pc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pc => pc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pc => !pc.DeletedDate.HasValue);

        // Foreign Key: UserId -> Users
        builder.HasOne(pc => pc.User)
           .WithMany() // Eğer User sınıfında PostComments koleksiyonu yoksa
           .HasForeignKey(pc => pc.UserId)
           .OnDelete(DeleteBehavior.NoAction); // Kaskadlı silmeyi devre dışı bırak

        // Foreign Key: ParentCommentId -> PostComments
        builder.HasOne(pc => pc.ParentComment)
            .WithMany(pc => pc.Replies)
            .HasForeignKey(pc => pc.ParentCommentId)
            .OnDelete(DeleteBehavior.NoAction); // Kaskadlı silmeyi devre dışı bırak

        // Foreign Key: PostId -> Posts
        builder.HasOne(pc => pc.Post)
            .WithMany(p => p.PostComments)
            .HasForeignKey(pc => pc.PostId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}  