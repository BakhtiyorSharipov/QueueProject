namespace Domain.Model;

public class ServiceEntity: BaseEntity
{
    public int CompanyId { get; set; }
    public string ServiceName { get; set; }
    public string ServiceDescription { get; set; }
    public List<EmployeeEntity> EmployeeEntities { get; set; } = new();
    public CompanyEntity CompanyEntity { get; set; }
}