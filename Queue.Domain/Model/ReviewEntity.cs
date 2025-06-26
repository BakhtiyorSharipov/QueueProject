namespace Domain.Model;

public class ReviewEntity: BaseEntity
{
    public int CustomerId { get; set; }
    public int EmployeeId { get; set; }
    public int QueueId { get; set; }
    public int Grade { get; set; }  
    public string? ReviewText { get; set; }
    
    public CustomerEntity CustomerEntity { get; set; }
    public EmployeeEntity EmployeeEntity { get; set; }
    public QueueEntity QueueEntity { get; set; }
}