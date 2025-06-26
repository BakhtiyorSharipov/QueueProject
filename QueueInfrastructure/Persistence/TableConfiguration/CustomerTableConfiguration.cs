using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging.Abstractions;

namespace QueueInfrastructure.Persistence.TableConfiguration;

public class CustomerTableConfiguration: IEntityTypeConfiguration<CustomerEntity>
{
    public void Configure(EntityTypeBuilder<CustomerEntity> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(s => s.Id);
        builder.HasAlternateKey(s => new { s.EmailAddres, s.PhoneNumber });
        builder.HasMany(s => s.ReviewEntities)
            .WithOne(s => s.CustomerEntity)
            .HasForeignKey(s=>new {s.CustomerId, s.EmployeeId, s.QueueId});
        builder.HasOne(s => s.BlockedCustomerEntity)
            .WithOne(s => s.CustomerEntity)
            .HasForeignKey<BlockedCustomerEntity>(s=>new {s.CustomerId, s.CompanyId});
        builder.HasMany(s => s.QueueEntities)
            .WithOne(s => s.CustomerEntity)
            .HasForeignKey(s => new { s.CustomerId, s.EmployeeId, s.ServiceId });
    }
}