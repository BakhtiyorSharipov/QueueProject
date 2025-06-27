using Application.Common.Interfaces.Repository;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using QueueInfrastructure.Persistence.DataBase;

namespace QueueInfrastructure.Persistence.Repositories;

public class CustomerRepository: Repository<CustomerEntity>, ICustomerRepository
{
    private readonly DbSet<CustomerEntity> _dbCustomer;
    private readonly DbContext _context;

    public CustomerRepository(EFContext context) : base(context)
    {
        _dbCustomer = context.Set<CustomerEntity>();
        _context = context;
    }
}