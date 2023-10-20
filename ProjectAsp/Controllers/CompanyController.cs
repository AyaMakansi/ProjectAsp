using Microsoft.AspNetCore.Mvc;
using ProjectAsp.Dtos;
using ProjectAsp.Services.company;

namespace ProjectAsp.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class CompanyController:ControllerBase
{
    private readonly ICompanyServices _companyServices;

    public CompanyController(ICompanyServices companyServices)
    {
        _companyServices = companyServices;
    }

    [HttpPost]
    public async Task<IActionResult> AddCompanyAsync([FromBody] CompanyDto dto)
    {
        var company = new Company
        {
            Comp_Name = dto.Comp_Name,
            Website = dto.Website,
            Date_Establishment = dto.Date_Establishment
        };
       await _companyServices.Add(company);
       return Ok(company);
    }
}