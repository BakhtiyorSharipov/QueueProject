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

        builder.HasMany(s => s.ReviewEntities)
            .WithOne(s => s.CustomerEntity)
            .HasForeignKey(s => s.CustomerId);

        builder.HasMany(s => s.QueueEntities)
            .WithOne(s => s.CustomerEntity)
            .HasForeignKey(s => s.CustomerId);
    }
}