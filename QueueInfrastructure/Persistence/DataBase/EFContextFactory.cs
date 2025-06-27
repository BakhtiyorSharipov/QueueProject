using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace QueueInfrastructure.Persistence.DataBase;

public class EFContextFactory: IDesignTimeDbContextFactory<EFContext>
{
    public EFContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<EFContext>();
        optionBuilder.UseNpgsql("Host=localhost;Port=5432;Database=QueueProject;Username=postgres;Password=b.sh.3242");
        return new EFContext(optionBuilder.Options);
    }
}