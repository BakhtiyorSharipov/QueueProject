using System.Net;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.Exceptions;
using Application.Requests.CompanyRequest;
using Application.Responses.CompanyResponse;
using AutoMapper;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services;

public class CompanyService: BaseService<CompanyEntity, CompanyResponseModel, CompanyRequestModel>,ICompanyService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;

    public CompanyService(ICompanyRepository repository, IMapper mapper): base(repository, mapper)
    {
        _companyRepository = repository;
        _mapper = mapper;
    }
    
    public override CompanyResponseModel Add(CompanyRequestModel request)
    {
        var parsedToCreate = request as CreateCompanyRequest;
        if (parsedToCreate == null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.BadRequest, nameof(CompanyEntity));
        }

        var mappedToCompany = _mapper.Map<CreateCompanyRequest, CompanyEntity>(parsedToCreate);
        _companyRepository.Add(mappedToCompany);
        _companyRepository.SaveChanges();

        return _mapper.Map<CompanyEntity, CompanyResponseModel>(mappedToCompany);
    }
    


    public override CompanyResponseModel GetById(int id)
    {
        var dbCompany = _companyRepository.FindById(id);
        if (dbCompany==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(CompanyEntity));
        }

        var mappedToResponse = _mapper.Map<CompanyEntity, CompanyResponseModel>(dbCompany);
        return mappedToResponse;
    }

    public override IEnumerable<CompanyResponseModel> GetAll(int pageList, int pageNumber)
    {
        var dbCompany = _companyRepository.GetAll(pageList, pageNumber);
        var mappedToResponse = _mapper.Map<IEnumerable<CompanyEntity>, IEnumerable<CompanyResponseModel>>(dbCompany);
        return mappedToResponse;
    }

    public override CompanyResponseModel Update(int id, CompanyRequestModel request)
    {
        var dbCompany = _companyRepository.FindById(id);
        if (dbCompany==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(CompanyEntity));
        }

        var companyRequestToUpdate = request as UpdateCompanyRequest;
        if (companyRequestToUpdate == null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.BadRequest, nameof(CompanyEntity));
        }
        var result = _mapper.Map(companyRequestToUpdate, dbCompany);
        _companyRepository.Update(dbCompany);
        _companyRepository.SaveChanges();
        return _mapper.Map<CompanyEntity, CompanyResponseModel>(dbCompany);
    }

    public override bool Delete(int id)
    {
        var dbCompany = _companyRepository.FindById(id);
        if (dbCompany==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(CompanyEntity));
        }
        
        _companyRepository.Delete(dbCompany);
        _companyRepository.SaveChanges();
        return true;
    }
}