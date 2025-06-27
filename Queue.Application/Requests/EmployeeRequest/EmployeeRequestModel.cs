namespace Application.Requests.EmployeeRequest;

public class EmployeeRequestModel: BaseRequest
{
    public int ServiceEntityId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
}