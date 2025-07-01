using System.Net;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.Exceptions;
using Application.Requests.ServiceRequest;
using Application.Responses.ServiceResponse;
using AutoMapper;
using Domain.Model;

namespace Application.Services;

public class ServiceService: BaseService<ServiceEntity, ServiceResponseModel, ServiceRequestModel>,IServiceService
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;

    public ServiceService(IServiceRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _serviceRepository = repository;
        _mapper = mapper;
    }

    public override ServiceResponseModel Add(ServiceRequestModel request)
    {
        var parsedToCreate = request as CreateServiceRequest;
        if (parsedToCreate==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(ServiceEntity));
        }

        var mappedToService = _mapper.Map<CreateServiceRequest, ServiceEntity>(parsedToCreate);
        _serviceRepository.Add(mappedToService);
        _serviceRepository.SaveChanges();
        
        return _mapper.Map<ServiceEntity, ServiceResponseModel>(mappedToService);

    }

    public override ServiceResponseModel GetById(int id)
    {
        var dbService = _serviceRepository.FindById(id);
        if (dbService==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(ServiceEntity));
        }

        var mappedToResponse = _mapper.Map<ServiceEntity, ServiceResponseModel>(dbService);
        return mappedToResponse;
    }

    public override IEnumerable<ServiceResponseModel> GetAll(int pageList, int pageNumber)
    {
        var dbService = _serviceRepository.GetAll(pageList, pageNumber);
        var mappedToResponse = _mapper.Map<IEnumerable<ServiceEntity>, IEnumerable<ServiceResponseModel>>(dbService);
        return mappedToResponse;
    }

    public override ServiceResponseModel Update(int id, ServiceRequestModel request)
    {
        var dbService = _serviceRepository.FindById(id);
        if (dbService==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(ServiceEntity));
        }

        var serviceRequestToUpdate = request as UpdateServiceRequest;
        var result = _mapper.Map(serviceRequestToUpdate, dbService);
        _serviceRepository.Update(dbService);
        _serviceRepository.SaveChanges();
        return _mapper.Map<ServiceEntity, ServiceResponseModel>(dbService);
    }

    public override bool Delete(int id)
    {
        var dbService = _serviceRepository.FindById(id);
        if (dbService==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(ServiceEntity));
        }
        _serviceRepository.Delete(dbService);
        _serviceRepository.SaveChanges();
        return true;
    }
}