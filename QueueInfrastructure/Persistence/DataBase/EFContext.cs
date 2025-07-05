using System.Reflection;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace QueueInfrastructure.Persistence.DataBase;

public class EFContext: DbContext
{
    public EFContext(DbContextOptions<EFContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=QueueProject;Username=postgres;Password=b.sh.3242");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<BaseEntity>();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TableConfiguration.CustomerTableConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}