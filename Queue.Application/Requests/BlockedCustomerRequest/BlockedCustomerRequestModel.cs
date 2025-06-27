namespace Application.Requests.BlockedCustomerRequest;

public class BlockedCustomerRequestModel: BaseRequest
{
    public int CompanyEntityId { get; set; }
    public int CustomerEntityId { get; set; }
    public string Reason { get; set; }
    public DateTime BannedUntil { get; set; }
    public bool DoesBandForever { get; set; }
}