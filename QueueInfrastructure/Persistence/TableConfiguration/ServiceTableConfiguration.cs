using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging.Abstractions;

namespace QueueInfrastructure.Persistence.TableConfiguration;

public class ServiceTableConfiguration: IEntityTypeConfiguration<ServiceEntity>
{
    public void Configure(EntityTypeBuilder<ServiceEntity> builder)
    {
        builder.ToTable("Services");
        builder.HasKey(s => s.Id);
        builder.HasOne(s => s.CompanyEntity)
            .WithMany(s => s.ServiceEntities).HasForeignKey(s=>s.CompanyId);
        builder.HasMany(s => s.EmployeeEntities)
            .WithOne(s => s.ServiceEntity).HasForeignKey(s=>s.ServiceId);
    }
}