using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserCertificateConfiguration : IEntityTypeConfiguration<UserCertificate>
{
    public void Configure(EntityTypeBuilder<UserCertificate> builder)
    {
        builder.ToTable("UserCertificates").HasKey(uc => uc.Id);

        builder.Property(uc => uc.Id).HasColumnName("Id").IsRequired();
        builder.Property(uc => uc.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(uc => uc.CertificateId).HasColumnName("CertificateId").IsRequired();
        builder.Property(uc => uc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(uc => uc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(uc => uc.DeletedDate).HasColumnName("DeletedDate");
        builder.HasQueryFilter(uc => !uc.DeletedDate.HasValue);
    }
}