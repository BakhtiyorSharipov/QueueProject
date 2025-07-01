using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.Requests.ReviewRequest;
using Application.Responses.ReviewResponse;
using Microsoft.AspNetCore.Mvc;

namespace QueueAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewController: ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet]
    public IEnumerable<ReviewResponseModel> Get(int pageList, int pageNumber)
    {
        return _reviewService.GetAll(pageList, pageNumber);
    }

    [HttpGet("{id}")]
    public ReviewResponseModel GetById(int id)
    {
        return _reviewService.GetById(id);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateReviewRequest reviewRequest)
    {
        var createdReview = _reviewService.Add(reviewRequest);
        return CreatedAtAction(nameof(GetById), new { id = createdReview.Id }, createdReview);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] ReviewRequestModel reviewRequest)
    {
        _reviewService.Update(id, reviewRequest);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _reviewService.Delete(id);
    }
}