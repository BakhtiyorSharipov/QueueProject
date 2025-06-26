using Application.Requests.CompanyRequest;
using Application.Responses.CompanyResponse;
using Domain.Model;

namespace Application.Common.Interfaces;


public interface ICompanyService: IBaseService<CompanyEntity, CompanyResponseModel, CompanyRequestModel>
{
    
}