using Application.Requests;
using Application.Responses;
using Domain.Model;
namespace Application.Common.Interfaces;

public interface IBaseService<TEntity, TResponseModel, TRequestModel>
    where TEntity: BaseEntity
    where TResponseModel: BaseResponse
    where TRequestModel: BaseRequest
{
    IEnumerable<TResponseModel> GetAll();
    TResponseModel GetById(int id);
    void Add(TRequestModel request);
    TResponseModel Update(int id, TRequestModel request);
    bool Delete(int id);
}