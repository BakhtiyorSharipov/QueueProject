namespace Application.Requests.ServiceRequest;

public class ServiceRequestModel: BaseRequest
{
    public int CompanyEntityId { get; set; }
    public string ServiceName { get; set; }
    public string ServiceDescription { get; set; }
}