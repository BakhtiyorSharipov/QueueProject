using System.Dynamic;
using Application.Common.Interfaces.Repository;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using QueueInfrastructure.Persistence.DataBase;

namespace QueueInfrastructure.Persistence.Repositories;

public class ServiceRepository: Repository<ServiceEntity>, IServiceRepository
{
    private readonly DbSet<ServiceEntity> _dbService;
    private readonly DbContext _context;

    public ServiceRepository(EFContext context) : base(context)
    {
        _dbService = context.Set<ServiceEntity>();
        _context = context;
    }
}