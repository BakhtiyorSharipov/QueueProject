using Application.Common.Interfaces;
using Application.Requests.CompanyRequest;
using Application.Responses.CompanyResponse;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace QueueAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyController: ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    //GET: api/<CompanyController>
    [HttpGet]
    public IEnumerable<CompanyResponseModel> Get(int pageList, int pageNumber)
    {
        return _companyService.GetAll(pageList, pageNumber);
    }

    //GET api<CompanyController>/5
    [HttpGet("{id}")]
    public CompanyResponseModel GetById([FromRoute]int id)
    {
        return _companyService.GetById(id);
    }

    
    //POST api/<CompanyController>
    [HttpPost]
    
    public IActionResult Post([FromBody] CreateCompanyRequest companyRequest)
    {
        var createdCompany = _companyService.Add(companyRequest);
        return CreatedAtAction(nameof(GetById), new { id = createdCompany.Id }, createdCompany);
    }

    //PUT api/<CompanyControoler>/5
    [HttpPut("{id}")]
    public void Put([FromRoute]int id, [FromBody] UpdateCompanyRequest companyRequest)
    {
        _companyService.Update(id, companyRequest);
    }

    //DELETE api<CompanyController>/5
    [HttpDelete("{id}")]
    public void Deleta([FromRoute]int id)
    {
        _companyService.Delete(id);
    }
    
}