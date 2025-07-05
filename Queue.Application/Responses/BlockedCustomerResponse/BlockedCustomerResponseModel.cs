using Domain.Model;
namespace Application.Responses.BlockedCustomerResponse;

public class BlockedCustomerResponseModel: BaseResponse
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public int CustomerId { get; set; }
    public string Reason { get; set; }
    public DateTime BannedUntil { get; set; }
    public bool DoesBandForever { get; set; }
    
}