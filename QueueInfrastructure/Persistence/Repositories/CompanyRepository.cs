using System.Diagnostics.Metrics;
using System.Security.AccessControl;
using Application.Common.Interfaces.Repository;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using QueueInfrastructure.Persistence.DataBase;

namespace QueueInfrastructure.Persistence.Repositories;

public class CompanyRepository: Repository<CompanyEntity>, ICompanyRepository
{
    private readonly DbSet<CompanyEntity> _dbCompany;
    private readonly EFContext _context;

    public CompanyRepository(EFContext context) : base(context)
    {
        _dbCompany = context.Set<CompanyEntity>();
        _context = context;
    }
}