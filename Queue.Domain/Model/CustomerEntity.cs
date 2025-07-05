namespace Domain.Model;

public class CustomerEntity: BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string EmailAddress { get; set; } 
    public List<ReviewEntity> ReviewEntities { get; set; } = new();
    public List<QueueEntity> QueueEntities { get; set; } = new();
}