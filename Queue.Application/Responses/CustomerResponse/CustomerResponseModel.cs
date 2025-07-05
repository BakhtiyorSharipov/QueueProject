using Domain.Model;
namespace Application.Responses.CustomerResponse;

public class CustomerResponseModel: BaseResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string EmailAddress { get; set; }
}