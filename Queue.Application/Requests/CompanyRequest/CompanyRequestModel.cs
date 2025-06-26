namespace Application.Requests.CompanyRequest;

public class CompanyRequestModel: BaseRequest
{
    public string CompanyName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }   
}