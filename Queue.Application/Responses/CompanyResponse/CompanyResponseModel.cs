using Domain.Model;
namespace Application.Responses.CompanyResponse;

public class CompanyResponseModel: BaseResponse
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public List<ServiceEntity> ServiceEntities { get; set; } = new();
}