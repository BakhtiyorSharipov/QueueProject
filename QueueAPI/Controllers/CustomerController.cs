using Application.Common.Interfaces;
using Application.Requests.CustomerRequest;
using Application.Responses.CustomerResponse;
using Microsoft.AspNetCore.Mvc;

namespace QueueAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CustomerController: ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public IEnumerable<CustomerResponseModel> Get(int pageList, int pageNumber)
    {
        return _customerService.GetAll(pageList, pageNumber);
    }

    [HttpGet("{id}")]
    public CustomerResponseModel GetById(int id)
    {
        return _customerService.GetById(id);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateCustomerRequest customerRequest)
    {
        var createdCustomer = _customerService.Add(customerRequest);
        return CreatedAtAction(nameof(GetById), new { id = createdCustomer.Id }, createdCustomer);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] CustomerRequestModel customerRequest)
    {
        _customerService.Update(id, customerRequest);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _customerService.Delete(id);
    }
}