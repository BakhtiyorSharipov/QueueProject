namespace Domain.Model;

public class CustomerEntity: BaseEntity
{
    public int BlockedCustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string EmailAddres { get; set; }

    public List<ReviewEntity> ReviewEntities { get; set; } = new();
    public BlockedCustomerEntity BlockedCustomerEntity { get; set; }
    public List<QueueEntity> QueueEntities { get; set; } = new();
}