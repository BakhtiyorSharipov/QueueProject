namespace Application.Requests.CustomerRequest;

public class CustomerRequestModel: BaseRequest
{
    public int BlockedCustomerEntityId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string EmailAddress { get; set; }
}