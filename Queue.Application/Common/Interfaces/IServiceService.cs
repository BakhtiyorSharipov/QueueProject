using Application.Requests.ServiceRequest;
using Application.Responses.ServiceResponse;
using Domain.Model;

namespace Application.Common.Interfaces;


public interface IServiceService: IBaseService<ServiceEntity, ServiceResponseModel, ServiceRequestModel>
{
    
}