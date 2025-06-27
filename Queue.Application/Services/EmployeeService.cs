using System.Globalization;
using System.Net;
using System.Net.Mime;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.Exceptions;
using Application.Requests.EmployeeRequest;
using Application.Responses.EmployeeResponse;
using AutoMapper;
using Domain.Model;

namespace Application.Services;

public class EmployeeService: BaseService<EmployeeEntity, EmployeeResponseModel, EmployeeRequestModel>,IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeeService(IEmployeeRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _employeeRepository = repository;
        _mapper = mapper;
    }

    public override void Add(EmployeeRequestModel request)
    {
        var parsedToCreate = request as CreateEmployeeRequest;
        if (parsedToCreate==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(EmployeeEntity));
        }

        var mappedToEmployee = _mapper.Map<CreateEmployeeRequest, EmployeeEntity>(parsedToCreate);
        _employeeRepository.Add(mappedToEmployee);
        _employeeRepository.SaveChanges();
    }

    public override EmployeeResponseModel GetById(int id)
    {
        var dbEmployee = _employeeRepository.FindById(id);
        if (dbEmployee==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(EmployeeEntity));
        }

        var mappedToResponse = _mapper.Map<EmployeeEntity, EmployeeResponseModel>(dbEmployee);
        return mappedToResponse;
    }

    public override IEnumerable<EmployeeResponseModel> GetAll(int pageList, int pageNumber)
    {
        var dbEmployee = _employeeRepository.GetAll(pageList, pageNumber);
        var mappedToResponse = _mapper.Map<IEnumerable<EmployeeEntity>, IEnumerable<EmployeeResponseModel>>(dbEmployee);
        return mappedToResponse;
    }

    public override EmployeeResponseModel Update(int id, EmployeeRequestModel request)
    {
        var dbEmployee = _employeeRepository.FindById(id);
        if (dbEmployee==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound);
        }

        var employeeRequestToUpdate = request as UpdateEmployeeRequest;
        var result = _mapper.Map(employeeRequestToUpdate, dbEmployee);
        _employeeRepository.Update(dbEmployee);
        _employeeRepository.SaveChanges();
        return _mapper.Map<EmployeeEntity, EmployeeResponseModel>(dbEmployee);
    }

    public override bool Delete(int id)
    {
        var dbEmployee = _employeeRepository.FindById(id);
        if (dbEmployee==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(EmployeeEntity));
        }
        _employeeRepository.Delete(dbEmployee);
        _employeeRepository.SaveChanges();
        return true;
    }
}