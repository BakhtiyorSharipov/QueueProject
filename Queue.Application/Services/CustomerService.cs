using System.Net;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.Exceptions;
using Application.Requests.CustomerRequest;
using Application.Responses.CustomerResponse;
using AutoMapper;
using Domain.Model;
using Microsoft.AspNetCore.Authentication;

namespace Application.Services;

public class CustomerService: BaseService<CustomerEntity, CustomerResponseModel, CustomerRequestModel>,ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository repository, IMapper mapper): base(repository, mapper)
    {
        _customerRepository = repository;
        _mapper = mapper;
    }

    public override CustomerResponseModel Add(CustomerRequestModel request)
    {
        var parsedToCreate = request as CreateCustomerRequest;
        if (parsedToCreate ==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(CustomerEntity));
        }

        var mappedToCustomer = _mapper.Map<CreateCustomerRequest, CustomerEntity>(parsedToCreate);
        _customerRepository.Add(mappedToCustomer);
        _customerRepository.SaveChanges();
        
        return _mapper.Map<CustomerEntity, CustomerResponseModel>(mappedToCustomer);

    }

    public override CustomerResponseModel GetById(int id)
    {
        var dbCustomer = _customerRepository.FindById(id);
        if (dbCustomer==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(CustomerEntity));
        }

        var mappedToResponse = _mapper.Map<CustomerEntity, CustomerResponseModel>(dbCustomer);
        return mappedToResponse;
    }

    public override IEnumerable<CustomerResponseModel> GetAll(int pageList, int pageNumber)
    {
        var dbCustomer = _customerRepository.GetAll(pageList, pageNumber);
        var mappedToResponse = _mapper.Map<IEnumerable<CustomerEntity>, IEnumerable<CustomerResponseModel>>(dbCustomer);
        return mappedToResponse;
    }

    public override CustomerResponseModel Update(int id, CustomerRequestModel request)
    {
        var dbCustomer = _customerRepository.FindById(id);
        if (dbCustomer==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(CustomerEntity));
        }

        var customerRequestToUpdate = request as UpdateCustomerRequest;
        var result = _mapper.Map(customerRequestToUpdate, dbCustomer);
        _customerRepository.Update(dbCustomer);
        _customerRepository.SaveChanges();
        return _mapper.Map<CustomerEntity, CustomerResponseModel>(dbCustomer);
    }

    public override bool Delete(int id)
    {
        var dbCustomer = _customerRepository.FindById(id);
        if (dbCustomer==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(CustomerEntity));
        }
        _customerRepository.Delete(dbCustomer);
        _customerRepository.SaveChanges();
        return true;
    }
}