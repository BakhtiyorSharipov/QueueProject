using Application.Common.Interfaces;
using Application.Requests.ServiceRequest;
using Application.Responses.ServiceResponse;
using Microsoft.AspNetCore.Mvc;

namespace QueueAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceController: ControllerBase
{
    private readonly IServiceService _serviceService;

    public ServiceController(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }
    
    [HttpGet]
    public IEnumerable<ServiceResponseModel> Get(int pageList, int pageNumber)
    {
        return _serviceService.GetAll(pageList, pageNumber);
    }

    [HttpGet("{id}")]
    public ServiceResponseModel GetById(int id)
    {
        return _serviceService.GetById(id);
    }

    [HttpPost]
    public void Post([FromBody] CreateServiceRequest serviceRequest)
    {
        _serviceService.Add(serviceRequest);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] ServiceRequestModel serviceRequest)
    {
        _serviceService.Update(id, serviceRequest);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _serviceService.Delete(id);
    }
}