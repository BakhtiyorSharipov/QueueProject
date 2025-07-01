using Application.Requests;
using Application.Responses;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Application.Common.Interfaces;

public interface IBaseService<TEntity, TResponseModel, TRequestModel>
    where TEntity: BaseEntity
    where TResponseModel: BaseResponse
    where TRequestModel: BaseRequest
{
    IEnumerable<TResponseModel> GetAll(int pageList, int pageNumber);
    TResponseModel GetById(int id);
    // void Add(TRequestModel request);
    TResponseModel Add(TRequestModel request);
    TResponseModel Update(int id, TRequestModel request);
    bool Delete(int id);
}