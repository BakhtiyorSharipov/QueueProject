using Domain.Model;
namespace Application.Responses.ReviewResponse;

public class ReviewResponseModel: BaseResponse
{
    public int Id { get; set; }
    public int CustomerEntityId { get; set; }
    public int EmployeeEntityId { get; set; }
    public int QueueEntityId { get; set; }
    public int Grade { get; set; }  
    public string? ReviewText { get; set; }
    
    public CustomerEntity CustomerEntity { get; set; }
    public EmployeeEntity EmployeeEntity { get; set; }
    public QueueEntity QueueEntity { get; set; }
}