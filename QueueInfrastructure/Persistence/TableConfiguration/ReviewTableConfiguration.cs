using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging.Abstractions;

namespace QueueInfrastructure.Persistence.TableConfiguration;

public class ReviewTableConfiguration: IEntityTypeConfiguration<ReviewEntity>
{
    public void Configure(EntityTypeBuilder<ReviewEntity> builder)
    {
        builder.ToTable("Reviews");
        builder.HasKey(s => s.Id);
        builder.HasOne(s => s.CustomerEntity)
            .WithMany(s => s.ReviewEntities)
            .HasForeignKey(s => s.CustomerId);

        builder.HasOne(s => s.EmployeeEntity)
            .WithMany()
            .HasForeignKey(s => s.EmployeeId);

        builder.HasOne(s => s.QueueEntity)
            .WithMany()
            .HasForeignKey(s => s.QueueId);
    }
}