using Domain.Model;
namespace Application.Responses.ServiceResponse;

public class ServiceResponseModel: BaseResponse
{
    public int Id { get; set; }
    public int CompanyEntityId { get; set; }
    public string ServiceName { get; set; }
    public string ServiceDescription { get; set; }
    // public List<EmployeeEntity> EmployeeEntities { get; set; } = new();
    // public CompanyEntity CompanyEntity { get; set; }
}