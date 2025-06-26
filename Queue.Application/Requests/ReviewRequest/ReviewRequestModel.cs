namespace Application.Requests.ReviewRequest;

public class ReviewRequestModel: BaseRequest
{
    public int CustomerId { get; set; }
    public int EmployeeId { get; set; }
    public int QueueId { get; set; }
    public int Grade { get; set; }  
    public string? ReviewText { get; set; }
}