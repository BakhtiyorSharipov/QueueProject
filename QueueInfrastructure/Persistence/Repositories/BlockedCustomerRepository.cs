using Application.Common.Interfaces.Repository;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using QueueInfrastructure.Persistence.DataBase;

namespace QueueInfrastructure.Persistence.Repositories;

public class BlockedCustomerRepository: Repository<BlockedCustomerEntity>, IBlockedCustomerRepository
{
    private readonly DbSet<BlockedCustomerEntity> _dbBlockedCustomer;
    private readonly DbContext _context;

    public BlockedCustomerRepository(EFContext context) : base(context)
    {
        _dbBlockedCustomer = context.Set<BlockedCustomerEntity>();
        _context = context;
    }
}