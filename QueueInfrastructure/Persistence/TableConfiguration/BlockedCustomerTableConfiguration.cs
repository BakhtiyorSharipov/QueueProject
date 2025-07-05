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

        builder.HasOne(s => s.CompanyEntity)
            .WithMany()
            .HasForeignKey(s => s.CompanyId);

        builder.HasOne(s => s.CustomerEntity)
            .WithMany()
            .HasForeignKey(s => s.CustomerId);
    }
}