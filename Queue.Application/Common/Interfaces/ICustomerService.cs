using Application.Requests.CustomerRequest;
using Application.Responses.CustomerResponse;
using Domain.Model;

namespace Application.Common.Interfaces;


public interface ICustomerService: IBaseService<CustomerEntity, CustomerResponseModel, CustomerRequestModel>
{
    
}