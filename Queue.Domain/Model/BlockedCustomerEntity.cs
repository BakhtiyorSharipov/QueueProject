namespace Domain.Model;

public class BlockedCustomerEntity: BaseEntity
{
    public int CompanyEntityId { get; set; }
    public int CustomerEntityId { get; set; }
    public string Reason { get; set; }
    public DateTime BannedUntil { get; set; }
    public bool DoesBandForever { get; set; }
    
    public CompanyEntity CompanyEntity { get; set; }
    public CustomerEntity CustomerEntity { get; set; }
}