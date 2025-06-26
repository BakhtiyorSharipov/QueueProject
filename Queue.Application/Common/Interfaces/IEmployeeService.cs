using Application.Requests.EmployeeRequest;
using Application.Responses.EmployeeResponse;
using Domain.Model;

namespace Application.Common.Interfaces;


public interface IEmployeeService: IBaseService<EmployeeEntity, EmployeeResponseModel, EmployeeRequestModel>
{
    
}