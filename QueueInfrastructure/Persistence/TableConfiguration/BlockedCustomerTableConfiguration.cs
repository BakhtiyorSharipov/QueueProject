using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging.Abstractions;

namespace QueueInfrastructure.Persistence.TableConfiguration;

public class BlockedCustomerTableConfiguration: IEntityTypeConfiguration<BlockedCustomerEntity>
{
    public void Configure(EntityTypeBuilder<BlockedCustomerEntity> builder)
    {
        builder.ToTable("BlockedCustomers");
        builder.HasKey(s => s.Id);
        builder.HasOne(s => s.CustomerEntity)
            .WithOne(s => s.BlockedCustomerEntity)
            .HasForeignKey<CustomerEntity>(s=>s.BlockedCustomerId);
    }
}