
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QueueInfrastructure.Persistence.TableConfiguration;
public class CompanyTableConfiguration: IEntityTypeConfiguration<CompanyEntity>
{
    public void Configure(EntityTypeBuilder<CompanyEntity> builder)
    {
        builder.ToTable("Companies");
        builder.HasKey(s => s.Id);
        builder.HasMany(s => s.ServiceEntities)
            .WithOne(s => s.CompanyEntity);
            // .HasForeignKey(s=>s.CompanyId);
        builder.HasAlternateKey(s => new {s.EmailAddress, s.PhoneNumber});
    }
}