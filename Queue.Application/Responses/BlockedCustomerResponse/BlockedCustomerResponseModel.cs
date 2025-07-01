using Domain.Model;
namespace Application.Responses.BlockedCustomerResponse;

public class BlockedCustomerResponseModel: BaseResponse
{
    public int Id { get; set; }
    public int CompanyEntityId { get; set; }
    public int CustomerEntityId { get; set; }
    public string Reason { get; set; }
    public DateTime BannedUntil { get; set; }
    public bool DoesBandForever { get; set; }
    // public CompanyEntity CompanyEntity { get; set; }
    // public CustomerEntity CustomerEntity { get; set; }
}