using Application.Common.Interfaces.Repository;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using QueueInfrastructure.Persistence.DataBase;

namespace QueueInfrastructure.Persistence.Repositories;

public class QueueRepository: Repository<QueueEntity>, IQueueRepository
{
    private readonly DbSet<QueueEntity> _dbQueue;
    private readonly DbContext _context;

    public QueueRepository(EFContext context) : base(context)
    {
        _dbQueue = context.Set<QueueEntity>();
        _context = context;
    }
}