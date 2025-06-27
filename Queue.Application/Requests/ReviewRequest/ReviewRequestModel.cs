namespace Application.Requests.ReviewRequest;

public class ReviewRequestModel: BaseRequest
{
    public int CustomerEntityId { get; set; }
    public int EmployeeEntityId { get; set; }
    public int QueueEntityId { get; set; }
    public int Grade { get; set; }  
    public string? ReviewText { get; set; }
}