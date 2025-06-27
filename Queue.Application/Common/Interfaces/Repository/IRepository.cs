using Domain.Model;

namespace Application.Common.Interfaces.Repository;

public interface IRepository<TEntity> where TEntity: BaseEntity
{
    TEntity FindById(int id);
    IQueryable<TEntity> GetAll(int pageList, int pageNumber);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    int SaveChanges();
}