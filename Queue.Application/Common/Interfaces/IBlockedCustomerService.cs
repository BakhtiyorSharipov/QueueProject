using Application.Requests.BlockedCustomerRequest;
using Application.Responses.BlockedCustomerResponse;
using Domain.Model;

namespace Application.Common.Interfaces;


public interface IBlockedCustomerService: IBaseService<BlockedCustomerEntity, BlockedCustomerResponseModel, BlockedCustomerRequestModel>
{
    
}