using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging.Abstractions;

namespace QueueInfrastructure.Persistence.TableConfiguration;

public class QueueTableConfiguration: IEntityTypeConfiguration<QueueEntity>
{
    public void Configure(EntityTypeBuilder<QueueEntity> builder)
    {
        builder.ToTable("Queues");
        builder.HasKey(s => s.Id);
        builder.HasOne(s => s.CustomerEntity)
            .WithMany(s => s.QueueEntities)
            .HasForeignKey(s => new { s.CustomerId, s.EmployeeId, s.ServiceId });
    }
}