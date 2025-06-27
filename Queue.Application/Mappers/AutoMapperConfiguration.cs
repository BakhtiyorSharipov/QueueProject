using Application.Requests.BlockedCustomerRequest;
using Application.Requests.CompanyRequest;
using Application.Requests.CustomerRequest;
using Application.Requests.EmployeeRequest;
using Application.Requests.QueueRequest;
using Application.Requests.ReviewRequest;
using Application.Requests.ServiceRequest;
using Application.Responses.BlockedCustomerResponse;
using Application.Responses.CompanyResponse;
using Application.Responses.CustomerResponse;
using Application.Responses.EmployeeResponse;
using Application.Responses.QueueResponse;
using Application.Responses.ReviewResponse;
using Application.Responses.ServiceResponse;
using AutoMapper;
using Domain.Model;

namespace Application.Mappers;

public class AutoMapperConfiguration: Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<CompanyRequestModel, CompanyEntity>();
        CreateMap<CompanyEntity, CompanyResponseModel>();
        CreateMap<UpdateCompanyRequest, CompanyEntity>();

        CreateMap<BlockedCustomerRequestModel, BlockedCustomerEntity>();
        CreateMap<BlockedCustomerEntity, BlockedCustomerResponseModel>();
        CreateMap<UpdateBlockedCustomerRequest, BlockedCustomerEntity>();

        CreateMap<CustomerRequestModel, CustomerEntity>();
        CreateMap<CustomerEntity, CustomerResponseModel>();
        CreateMap<UpdateCustomerRequest, CustomerEntity>();

        CreateMap<EmployeeRequestModel, EmployeeEntity>();
        CreateMap<EmployeeEntity, EmployeeResponseModel>();
        CreateMap<UpdateEmployeeRequest, EmployeeEntity>();

        CreateMap<QueueResponseModel, QueueEntity>();
        CreateMap<QueueEntity, QueueResponseModel>();
        CreateMap<UpdateQueueRequest, QueueEntity>();

        CreateMap<ReviewRequestModel, ReviewEntity>();
        CreateMap<ReviewEntity, ReviewResponseModel>();
        CreateMap<UpdateReviewRequest, ReviewEntity>();

        CreateMap<ServiceRequestModel, ServiceEntity>();
        CreateMap<ServiceEntity, ServiceResponseModel>();
        CreateMap<UpdateServiceRequest, ServiceEntity>();
    }
}