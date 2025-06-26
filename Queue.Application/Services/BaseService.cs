using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.Requests;
using Application.Responses;
using AutoMapper;
using Domain.Model;

namespace Application.Services;

public abstract class BaseService<TEntity, TResponseModel, TRequestModel>: IBaseService<TEntity, TResponseModel, TRequestModel>
    where TEntity: BaseEntity
    where TResponseModel: BaseResponse
    where TRequestModel: BaseRequest
{
    private readonly IRepository<TEntity> _repository;
    private readonly IMapper _mapper;

    public BaseService(IRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper; 
    }

    public virtual void Add(TRequestModel request)
    {
        throw new NotImplementedException();
    }

    public virtual bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public virtual TResponseModel Update(int id, TRequestModel request)
    {
        throw new NotImplementedException();
    }

    public virtual IEnumerable<TResponseModel> GetAll(int pageList, int pageNumber)
    {
        throw new NotImplementedException();
    }

    public virtual TResponseModel GetById(int id)
    {
        throw new NotImplementedException();
    }
    
}