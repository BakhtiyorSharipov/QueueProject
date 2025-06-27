namespace Domain.Model;

public class EmployeeEntity: BaseEntity
{
    public int ServiceEntityId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string  Position { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    
    public ServiceEntity ServiceEntity { get; set; }
    public List<QueueEntity> QueueEntities { get; set; } = new();
}