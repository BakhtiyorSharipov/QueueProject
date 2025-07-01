using Application.Common.Interfaces;
using Application.Requests.EmployeeRequest;
using Application.Requests.QueueRequest;
using Application.Responses.QueueResponse;
using Microsoft.AspNetCore.Mvc;

namespace QueueAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class QueueController: ControllerBase
{
    private readonly IQueueService _queueService;

    public QueueController(IQueueService queueService)
    {
        _queueService = queueService;
    }

    [HttpGet]
    public IEnumerable<QueueResponseModel> Get(int pageList, int pageNumber)
    {
        return _queueService.GetAll(pageList, pageNumber);
    }

    [HttpGet("{id}")]
    public QueueResponseModel GetById(int id)
    {
        return _queueService.GetById(id);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateQueueRequest queueRequest)
    {
        var createdQueue = _queueService.Add(queueRequest);
        return CreatedAtAction(nameof(GetById), new { id = createdQueue.Id }, createdQueue);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] QueueRequestModel requestModel)
    {
        _queueService.Update(id, requestModel);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _queueService.Delete(id);
    }
    
}