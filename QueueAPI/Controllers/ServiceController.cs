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
    public ServiceResponseModel GetById([FromRoute]int id)
    {
        return _serviceService.GetById(id);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateServiceRequest serviceRequest)
    {
        var createdService = _serviceService.Add(serviceRequest);
        return CreatedAtAction(nameof(GetById), new { id = createdService.Id }, createdService);
    }

    [HttpPut("{id}")]
    public void Put([FromRoute]int id, [FromBody] ServiceRequestModel serviceRequest)
    {
        _serviceService.Update(id, serviceRequest);
    }

    [HttpDelete("{id}")]
    public void Delete([FromRoute]int id)
    {
        _serviceService.Delete(id);
    }
}