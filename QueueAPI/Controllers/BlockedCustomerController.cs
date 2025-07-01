using Application.Common.Interfaces;
using Application.Requests.BlockedCustomerRequest;
using Application.Responses.BlockedCustomerResponse;
using Microsoft.AspNetCore.Mvc;

namespace QueueAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlockedCustomerController: ControllerBase
{
    private readonly IBlockedCustomerService _blockedCustomerService;

    public BlockedCustomerController(IBlockedCustomerService blockedCustomerService)
    {
        _blockedCustomerService = blockedCustomerService;
    }

    [HttpGet]
    public IEnumerable<BlockedCustomerResponseModel> Get(int pageList, int pageNumber)
    {
        return _blockedCustomerService.GetAll(pageList, pageNumber);
    }

    [HttpGet("{id}")]
    public BlockedCustomerResponseModel GetById(int id)
    {
        return _blockedCustomerService.GetById(id);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateBlockedCustomerRequest blockedCustomerRequest)
    {
        var createdBlockedCustomer = _blockedCustomerService.Add(blockedCustomerRequest);
        return CreatedAtAction(nameof(GetById), new { id = createdBlockedCustomer.Id }, createdBlockedCustomer);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] BlockedCustomerRequestModel blockedCustomerRequest)
    {
        _blockedCustomerService.Update(id, blockedCustomerRequest);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _blockedCustomerService.Delete(id);
    }
}