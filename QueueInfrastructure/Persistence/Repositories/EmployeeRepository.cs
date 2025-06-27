using Application.Common.Interfaces.Repository;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using QueueInfrastructure.Persistence.DataBase;

namespace QueueInfrastructure.Persistence.Repositories;

public class EmployeeRepository: Repository<EmployeeEntity>, IEmployeeRepository
{
    private readonly DbSet<EmployeeEntity> _dbEmployee;
    private readonly EFContext _context;

    public EmployeeRepository(EFContext context) : base(context)
    {
        _dbEmployee = context.Set<EmployeeEntity>();
        _context = context;
    }
}