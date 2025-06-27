namespace Domain.Model;

public class QueueEntity: BaseEntity
{
    public int EmployeeEntityId { get; set; }
    public int CustomerEntityId { get; set; }
    public int ServiceEntityId { get; set; }
    public string DayOfWeek { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string CancelReason { get; set; }
    
    public EmployeeEntity EmployeeEntity { get; set; }
    public CustomerEntity CustomerEntity { get; set; }
    public ServiceEntity ServiceEntity { get; set; }
}