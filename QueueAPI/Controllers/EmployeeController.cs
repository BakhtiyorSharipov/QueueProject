using Application.Common.Interfaces;
using Application.Requests.EmployeeRequest;
using Application.Responses.EmployeeResponse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace QueueAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController: ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public IEnumerable<EmployeeResponseModel> Get(int pageList, int pageNumber)
    {
        return _employeeService.GetAll(pageList, pageNumber);
    }

    [HttpGet("{id}")]
    public EmployeeResponseModel GetById(int id)
    {
        return _employeeService.GetById(id);
    }

    [HttpPost] 
    public void Post([FromBody] CreateEmployeeRequest employeeRequest)
    {
        _employeeService.Add(employeeRequest);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] EmployeeRequestModel requestModel)
    {
        _employeeService.Update(id, requestModel);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _employeeService.Delete(id);
    }
    
}