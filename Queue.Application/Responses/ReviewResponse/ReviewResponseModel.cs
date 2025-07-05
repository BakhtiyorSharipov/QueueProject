using Domain.Model;
namespace Application.Responses.ReviewResponse;

public class ReviewResponseModel: BaseResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int EmployeeId { get; set; }
    public int QueueId { get; set; }
    public int Grade { get; set; }  
    public string? ReviewText { get; set; }

}