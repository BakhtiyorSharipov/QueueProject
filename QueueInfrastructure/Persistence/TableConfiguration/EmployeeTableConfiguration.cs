using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging.Abstractions;

namespace QueueInfrastructure.Persistence.TableConfiguration;

public class EmployeeTableConfiguration: IEntityTypeConfiguration<EmployeeEntity>   
{
    public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
    {
        builder.ToTable("Employees");
        builder.HasKey(s => s.Id);
        builder.HasAlternateKey(s => new { s.EmailAddress, s.PhoneNumber });
        builder.HasOne(s => s.ServiceEntity)
            .WithMany(s => s.EmployeeEntities);
            // .HasForeignKey(s=>s.ServiceId);
        builder.HasMany(s => s.QueueEntities)
            .WithOne(s => s.EmployeeEntity);
            // .HasForeignKey(s => new { s.CustomerId, s.ServiceId, s.EmployeeId });
    }
}