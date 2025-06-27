using System.Security.AccessControl;
using Application.Common.Interfaces.Repository;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using QueueInfrastructure.Persistence.DataBase;

namespace QueueInfrastructure.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly DbSet<TEntity> _set;
    private readonly EFContext _context;

    public Repository(EFContext context)
    {
        _set = context.Set<TEntity>();
        _context = context;
    }
    public TEntity FindById(int id)
    {
        var foundEntity = _set.Find(id);
        if (foundEntity==null)
        {
            throw new ArgumentNullException(nameof(foundEntity));
        }

        return foundEntity;
    }

    public IQueryable<TEntity> GetAll(int pageList, int pageNumber)
    {
        return _set.Skip<TEntity>(pageList * pageNumber).Take<TEntity>(pageList);
    }

    public void Add(TEntity entity)
    {
        _set.Add(entity);
    }

    public void Update(TEntity entity)
    {
        _set.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _set.Remove(entity);
    }

    public int SaveChanges()=>_context.SaveChanges();
    
}